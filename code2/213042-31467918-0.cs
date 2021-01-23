    /// <summary>
    /// An extension method to add a repeat click feature to a button. Clicking and holding  on a button will cause it
    /// to repeatedly fire. This is useful for up-down spinner buttons. Typically the longer the mouse is held, the
    /// more quickly the click events are fired. There are different options when it comes to increasing the rate of
    /// clicks:
    /// 1) Exponential - this is the mode used in the NumericUpDown buttons. The first delay starts off around 650 ms
    /// and each successive delay is multiplied by 75% of the current delay.
    /// 2) Linear - the delay more slowly reaches the fastest repeat speed. Each successive delay subtracts a fixed
    /// amount from the current delay. Decreases in delays occur half a second apart.
    /// 3) Two Speed - this delay starts off at a slow speed, and then increases to a faster speed after a specified delay.
    /// 4) Three Speed - the repeat speed can increase from slow, to medium, to fastest after a specified delay.
    ///
    /// If repeating is added to a button that already has it, then it will be replaced with the new values.
    /// </summary>
    public static class RepeatingButtonEx {
    
    	private static Hashtable ht = new Hashtable();
    	private class Data {
    		private static readonly System.Reflection.MethodInfo methodOnClick = null;
    		static Data() {
    			methodOnClick = typeof(Button).GetMethod("OnClick", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    		}
    
    		public Button Button = null;
    		private Timer Timer = new Timer();
    		public double? GradientRate;
    		public int? LinearGradient = null;
    		public int FirstDelayMillis;
    		public int FastestRepeatMillis;
    		public int[] SwitchesMillis;
    		public int[] SpeedsMillis;
    
    		private DateTime lastEvent = DateTime.MinValue;
    		private int millisCount = 0;
    		private int currentSpeed = 0;
    		private int waitSum = 0;
    
    		public Data(Button button, double? gradientRate, int? linearGradient, int firstDelayMillis, int fastestRepeatMillis, int[] switchesMillis, int[] speedsMillis) {
    			Button = button;
    			GradientRate = gradientRate;
    			LinearGradient = linearGradient;
    			FirstDelayMillis = firstDelayMillis;
    			FastestRepeatMillis = fastestRepeatMillis;
    			SwitchesMillis = switchesMillis;
    			SpeedsMillis = speedsMillis;
    			Timer.Interval = firstDelayMillis;
    			Timer.Tick += Timer_Tick;
    			Button.MouseDown += Button_MouseDown;
    			Button.MouseUp += Button_MouseUp;
    			Button.MouseLeave += Button_MouseLeave;
    		}
    
    		void Button_MouseDown(object sender, MouseEventArgs e) {
    			if (!Button.Enabled)
    				return;
    
    			lastEvent = DateTime.UtcNow;
    			Timer.Start();
    		}
    
    		void Button_MouseUp(object sender, MouseEventArgs e) {
    			Reset();
    		}
    
    		void Button_MouseLeave(object sender, EventArgs e) {
    			Reset();
    		}
    
    		private void Reset() {
    			Timer.Stop();
    			Timer.Interval = FirstDelayMillis;
    			millisCount = 0;
    			currentSpeed = 0;
    			waitSum = 0;
    		}
    
    		void Timer_Tick(object sender, EventArgs e) {
    			if (!Button.Enabled) {
    				Reset();
    				return;
    			}
    
    			methodOnClick.Invoke(Button, new Object[] { EventArgs.Empty });
    			//Button.PerformClick(); // if Button uses SetStyle(Selectable, false); then CanSelect is false, which prevents PerformClick from working.
    
    			if (GradientRate.HasValue || LinearGradient.HasValue) {
    				int millis = Timer.Interval;
    
    				if (GradientRate.HasValue)
    					millis = (int) Math.Round(GradientRate.Value * millis);
    				else if (LinearGradient.HasValue) {
    					DateTime now = DateTime.UtcNow;
    					var ts = now - lastEvent;
    					int ms = (int) ts.TotalMilliseconds;
    					millisCount += ms;
    					// only increase the rate every 500 milliseconds
    					// otherwise it appears too get to the maximum rate too quickly
    					if (millisCount >= 500) {
    						millis -= LinearGradient.Value;
    						millisCount -= 500;
    						lastEvent = now;
    					}
    				}
    
    				if (millis < FastestRepeatMillis)
    					millis = FastestRepeatMillis;
    
    				Timer.Interval = millis;
    			}
    			else {
    				if (currentSpeed < SpeedsMillis.Length) {
    					TimeSpan elapsed = DateTime.UtcNow - lastEvent;	
    					if (elapsed.TotalMilliseconds >= waitSum) {
    						waitSum += SwitchesMillis[currentSpeed];
    						Timer.Interval = SpeedsMillis[currentSpeed];
    						currentSpeed++;
    					}
    				}
    			}
    		}
    
    		public void Dispose() {
    			Timer.Stop();
    			Timer.Dispose();
    			Button.MouseDown -= Button_MouseDown;
    			Button.MouseUp -= Button_MouseUp;
    			Button.MouseLeave -= Button_MouseLeave;
    		}
    	}
    
    	///<summary>The repeating speed becomes exponentially faster. This is the default behavior of the NumericUpDown control.</summary>
    	///<param name="button">The button to add the behavior.<param>
    	///<param name="firstDelayMillis">The delay before first repeat in milliseconds.</param>
    	///<param name="fastestRepeatMillis">The smallest delay allowed. Note: Masharling between the timer and the UI thread has an unavoidable limit of about 10 milliseconds.</param>
    	///<param name="gradientRate">The new interval is the current interval multiplied by the gradient rate.</param>
    	public static void AddRepeatingExponential(this Button button, int firstDelayMillis = 500, int fastestRepeatMillis = 15, double gradientRate = 0.75) {
    		AddRepeating(button, firstDelayMillis, fastestRepeatMillis, gradientRate, null, null, null);
    	}
    
    	///<summary>The repeating speed becomes linearily faster.</param>
    	///<param name="button">The button to add the behavior.<param>
    	///<param name="firstDelayMillis">The delay before first repeat in milliseconds.</param>
    	///<param name="fastestRepeatMillis">The smallest delay allowed. Note: Masharling between the timer and the UI thread has an unavoidable limit of about 10 milliseconds.</param>
    	///<param name="linearGradient">If specified, the repeats gradually happen more quickly. The new interval is the current interval minus the linear gradient.</param>
    	public static void AddRepeatingLinear(this Button button, int firstDelayMillis = 500, int fastestRepeatMillis = 50, int linearGradient = 25) {
    		AddRepeating(button, firstDelayMillis, fastestRepeatMillis, null, linearGradient, null, null);
    	}
    
    	///<summary>The repeating speed switches from the slow speed to the fastest speed after the specified amount of milliseconds.</summary>
    	///<param name="button">The button to add the behavior.<param>
    	///<param name="firstDelayMillis">The delay before first repeat in milliseconds.</param>
    	///<param name="fastestRepeatMillis">The smallest delay allowed. Note: Masharling between the timer and the UI thread has an unavoidable limit of about 10 milliseconds.</param>
    	///<param name="slowRepeatMillis">The delay in milliseconds between repeats when in the slow repeat state.</param>
    	///<param name="slowToFastestSwitchMillis">The delay in milliseconds before switching from the slow repeat speed to the fastest repeat speed.</param>
    	public static void AddRepeatingTwoSpeed(this Button button, int firstDelayMillis = 500, int fastestRepeatMillis = 100, int slowRepeatMillis = 300, int slowToFastestSwitchMillis = 2000) {
    		AddRepeating(button, firstDelayMillis, fastestRepeatMillis, null, null, new[] { slowRepeatMillis, fastestRepeatMillis }, new [] { slowToFastestSwitchMillis, 0 });
    	}
    
    	///<summary>The repeating speed switches from the slow to medium to fastest at speed switch interval specified.</summary>
    	///<param name="button">The button to add the behavior.<param>
    	///<param name="firstDelayMillis">The delay before first repeat in milliseconds.</param>
    	///<param name="fastestRepeatMillis">The smallest delay allowed. Note: Masharling between the timer and the UI thread has an unavoidable limit of about 10 milliseconds.</param>
    	///<param name="slowRepeatMillis">The delay in milliseconds between repeats when in the slow repeat state.</param>
    	///<param name="mediumRepeatMillis">The delay in milliseconds between repeats when in the medium repeat state.</param>
    	///<param name="speedSwitchMillis">The delay in milliseconds before switching from one speed state to the next speed state.</param>
    	public static void AddRepeatingThreeSpeed(this Button button, int firstDelayMillis = 500, int fastestRepeatMillis = 75, int slowRepeatMillis = 300, int mediumRepeatMillis = 150, int speedSwitchMillis = 2000) {
    		AddRepeating(button, firstDelayMillis, fastestRepeatMillis, null, null, new[] { slowRepeatMillis, mediumRepeatMillis, fastestRepeatMillis }, new [] { speedSwitchMillis, speedSwitchMillis, 0 });
    	}
    
    	private static void AddRepeating(this Button button, int firstDelayMillis, int fastestRepeatMillis, double? gradientRate, int? linearGradient, int[] speedsMillis, int[] switchesMillis) {
    		Data d = (Data) ht[button];
    		if (d != null)
    			RemoveRepeating(button);
    
    		d = new Data(button, gradientRate, linearGradient, firstDelayMillis, fastestRepeatMillis, switchesMillis, speedsMillis);
    		ht[button] = d;
    		button.Disposed += delegate {
    			RemoveRepeating(button);
    		};
    	}
    
    	///<summary>Removes the repeating behavior from the button.</summary>
    	public static void RemoveRepeating(this Button button) {
    		Data d = (Data) ht[button];
    		if (d == null)
    			return;
    
    		ht.Remove(button);
    		d.Dispose();
    	}
    }
