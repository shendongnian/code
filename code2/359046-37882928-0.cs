    using Mono.Unix.Native;
    namespace drone.StackOverflow{
    
	  internal class LinuxHiResTimer {
		internal event EventHandler Tick; // Tick event 
		private System.Diagnostics.Stopwatch watch; // High resolution time
		const uint safeDelay = 0; // millisecond (for slightly early wakeup)
		private Timespec pendingNanosleepParams = new Timespec();
		private Timespec threadNanosleepParams = new Timespec();
		object lockObject = new object();
		internal long Interval { 
			get{
				double totalNanoseconds;
				lock (lockObject) {
					totalNanoseconds= (1e9 * pendingNanosleepParams.tv_sec)
					                         + pendingNanosleepParams.tv_nsec; 
			
				
				}
				return (int)(totalNanoseconds * 1e-6);//return value in ms
			} 
			set{
				lock (lockObject) {
					pendingNanosleepParams.tv_sec = value / 1000;
					pendingNanosleepParams.tv_nsec = (long)((value % 1000) * 1e6);//set value in ns
				}
			}
		}
		private bool enabled;
		internal bool Enabled {
			get { return enabled; }
			set {
				if (value) {
					watch.Start();
					enabled = value;
					Task.Run(()=>tickGenerator()); // fire up new thread
				}
				else {
					lock (lockObject) {
						enabled = value;
					}
				}
			}
		}
		private Task tickGenerator() {
			bool bNotPendingStop; 
			lock (lockObject) {
				bNotPendingStop = enabled;
			}
			while (bNotPendingStop) {
				// Check if thread has been told to halt
				lock (lockObject) {
					bNotPendingStop = enabled;
				}
				long curTime = watch.ElapsedMilliseconds;
					if (curTime >= Interval) {
						watch.Restart ();
						if (Tick != null)
							Tick (this, new EventArgs ());
					} else {
						long iTimeLeft = (Interval - curTime); // How long to delay for 
						if (iTimeLeft >= safeDelay) { // Task.Delay has resolution 15ms//await Task.Delay(TimeSpan.FromMilliseconds(iTimeLeft - safeDelay));
							threadNanosleepParams.tv_nsec = (int)((iTimeLeft - safeDelay) * 1e6);
							threadNanosleepParams.tv_sec = 0;
							Syscall.nanosleep (ref threadNanosleepParams, ref threadNanosleepParams);
						}
					}
				
			}
			watch.Stop();
			return null;
		}
    }
