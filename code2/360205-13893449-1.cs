using System;
using System.Threading;
using System.Windows.Forms;
  class TimerExample
  {
      static public void Tick(Object stateInfo)
      {
       
 		  
	  if(DateTime.Now.ToString("h:mm:ss") == "8:00:00")
		{	
			MessageBox.Show("Time to brush your teeth!");
		}
	  if(DateTime.Now.ToString("h:mm:ss") == "9:00:00")
		{	
			MessageBox.Show("Time for your favorite show!");
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
