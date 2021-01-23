using System;
using System.Threading;
using System.Windows.Forms;
  class TimerExample
  {
      static public void Tick(Object stateInfo)
      {
       
 
	  if(DateTime.Now.ToString("h:mm") == "1:00")
		{	
			MessageBox.Show("Time to brush your teeth! " + DateTime.Now.ToString("h:mm"));
		}
 
	  if(DateTime.Now.ToString("h:mm") == "9:30")
		{	
			MessageBox.Show("Time to brush your teeth! " + DateTime.Now.ToString("h:mm"));
		}
	  if(DateTime.Now.ToString("h:mm") == "10:00")
		{	
			MessageBox.Show("Time for your favorite show! "+ DateTime.Now.ToString("h:mm"));
		}
      }
      static void Main()
      {
          TimerCallback callback = new TimerCallback(Tick);
          Console.WriteLine("Creating timer: {0}\n", 
                             DateTime.Now.ToString("h:mm:ss"));
          // create a one second timer tick
          System.Threading.Timer stateTimer = new System.Threading.Timer(callback, null, 0, 1000);
          // loop here forever
          for (; ; ) { }
      }
  }
