using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
  class TimerExample
  {
      static void Main()
      {
          bool JobIsEnabledA = true;
		  bool JobIsEnabledB = true;
		  bool JobIsEnabledC = true;
          Console.WriteLine("Starting at: {0}\n", 
                             DateTime.Now.ToString("h:mm:ss"));
          // loop here forever
          for (; ; ) { 
		  
		  if(DateTime.Now.ToString("h:mm") == "2:10" && JobIsEnabledA == true)
			{	
			
				JobIsEnabledA = false;
			
				ThreadPool.QueueUserWorkItem((state) => { MessageBox.Show("Time to brush your teeth! " + DateTime.Now.ToString("h:mm")); });
			}
 
		if(DateTime.Now.ToString("h:mm") == "2:20"  && JobIsEnabledB == true)
			{	
				JobIsEnabledB = false;
			
				ThreadPool.QueueUserWorkItem((state) => { MessageBox.Show("Time to brush your teeth! " + DateTime.Now.ToString("h:mm")); });
			}
		if(DateTime.Now.ToString("h:mm") == "2:30"  && JobIsEnabledC == true)
			{	
				JobIsEnabledC = false;
			
				ThreadPool.QueueUserWorkItem((state) => { MessageBox.Show("Time for your favorite show! "+ DateTime.Now.ToString("h:mm")); });
			}
		if(DateTime.Now.ToString("h:mm") == "2:31")
			{	
				JobIsEnabledA = true;
				JobIsEnabledB = true;
				JobIsEnabledC = true;
				
			}		
		
		using (StreamWriter w = new StreamWriter("c:\\scheduler.log", true))
			{
				w.WriteLine(DateTime.Now.ToString("h:mm:ss") + " JobIsEnabledA: " + JobIsEnabledA + " JobIsEnabledB:" + JobIsEnabledB + " JobIsEnabledC: " + JobIsEnabledC);
			}	
		  
		  
			Thread.Sleep(1000);
		  }
      }
  }
  
