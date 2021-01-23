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
		  
		  if(DateTime.Now.ToString("h:mm") == "1:50" && JobIsEnabledA == true)
			{	
			
				JobIsEnabledA = false;
			
				MessageBox.Show("Time to brush your teeth! " + DateTime.Now.ToString("h:mm"));
			}
 
		if(DateTime.Now.ToString("h:mm") == "2:00"  && JobIsEnabledB == true)
			{	
				JobIsEnabledB = false;
			
				MessageBox.Show("Time to brush your teeth! " + DateTime.Now.ToString("h:mm"));
			}
		if(DateTime.Now.ToString("h:mm") == "2:10"  && JobIsEnabledC == true)
			{	
				JobIsEnabledC = false;
			
				MessageBox.Show("Time for your favorite show! "+ DateTime.Now.ToString("h:mm"));
			}
		if(DateTime.Now.ToString("h:mm") == "2:11")
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
