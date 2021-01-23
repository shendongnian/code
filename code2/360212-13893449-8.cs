    using System;
    using System.Threading;
    using System.Windows.Forms;
    using System.IO;
     
    public class TimerExample
    {
    	public static void Main()
    	{
    		bool jobIsEnabledA = true;
    		bool jobIsEnabledB = true;
    		bool jobIsEnabledC = true;
     
    		Console.WriteLine("Starting at: {0}", DateTime.Now.ToString("h:mm:ss"));
     
    		try
    		{
    			using (StreamWriter writer = File.AppendText("C:\\scheduler_log.txt"))
    			{
    				while (true)
    				{
    					var currentTime = DateTime.Now.ToString("h:mm");
     
    					if (currentTime == "3:15" && jobIsEnabledA)
    					{
    						jobIsEnabledA = false;
    						ThreadPool.QueueUserWorkItem((state) => { MessageBox.Show(string.Format("Time to brush your teeth! {0}", currentTime) ); });
    					}
    		 
    					if (currentTime == "3:20" && jobIsEnabledB)
    					{
    						jobIsEnabledB = false;
    						ThreadPool.QueueUserWorkItem((state) => { MessageBox.Show(string.Format("Time to brush your teeth! {0}", currentTime)); });
    					}
    					
    					if (currentTime == "3:30" && jobIsEnabledC)
    					{      
    						jobIsEnabledC = false;
    						ThreadPool.QueueUserWorkItem((state) => { MessageBox.Show(string.Format("Time for your favorite show! {0}", currentTime)); });
    					}
    		 
    					if (currentTime == "3:31")
    					{      
    						jobIsEnabledA = true;
    						jobIsEnabledB = true;
    						jobIsEnabledC = true;
    					}
     
    					var logText = string.Format("{0} jobIsEnabledA: {1} jobIsEnabledB: {2} jobIsEnabledC: {3}", DateTime.Now.ToString("h:mm:ss"), jobIsEnabledA, jobIsEnabledB, jobIsEnabledC);
    					writer.WriteLine(logText);
     
    					Thread.Sleep(1000);
    				}
    			}
    		}
    		catch (Exception exception)
    		{
    			Console.WriteLine(exception);
    		}
    	}
    }
