	public class ClassUnderTest
	{
		private MyComponent myComponent;
		
		public ClassUnderTest(MyComponent myComponent)
		{
			this.myComponent = myComponent;
		}
		
		public void MethodUnderTest()
		{
			dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
			dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
			dispatcherTimer.Interval = new TimeSpan(0,0,1);
			dispatcherTimer.Start();
			// ...
		}
		
		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			if(!myComponent.IsBusy())
			{
				// do something else now...
			}
		}
	}
	
	public class MyComponent
	{
		public virtual bool IsBusy()
		{
			// some implementation that will be faked via the Do Handler
			return false;
		}
	}
