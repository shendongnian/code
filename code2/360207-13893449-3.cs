using System;
using System.Threading;
using System.Windows.Forms;
  class TimerExample
  {
      static public void Tick(Object stateInfo)
      {
       
 
	  if(DateTime.Now.ToString("h:mm") == "1:00" && GlobalClass.GlobalVarA == true)
		{	
			
			GlobalClass.GlobalVarA = false;
			
			MessageBox.Show("Time to brush your teeth! " + DateTime.Now.ToString("h:mm"));
		}
 
	  if(DateTime.Now.ToString("h:mm") == "9:45"  && GlobalClass.GlobalVarB == true)
		{	
			GlobalClass.GlobalVarB = false;
			
			MessageBox.Show("Time to brush your teeth! " + DateTime.Now.ToString("h:mm"));
		}
	  if(DateTime.Now.ToString("h:mm") == "10:00"  && GlobalClass.GlobalVarC == true)
		{	
			GlobalClass.GlobalVarC = false;
			
			MessageBox.Show("Time for your favorite show! "+ DateTime.Now.ToString("h:mm"));
		}
	  if(DateTime.Now.ToString("h:mm") == "10:01")
		{	
			GlobalClass.GlobalVarA = true;
			GlobalClass.GlobalVarB = true;
			GlobalClass.GlobalVarC = true;
			
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
  
static class GlobalClass
    {
        private static bool a_globalVar = true;
        private static bool b_globalVar = true;
		private static bool c_globalVar = true;
		
        public static bool GlobalVarA
        {
            get { return a_globalVar; }
            set { a_globalVar = value; }
        }
        public static bool GlobalVarB
        {
            get { return b_globalVar; }
            set { b_globalVar = value; }
        }
        public static bool GlobalVarC
        {
            get { return c_globalVar; }
            set { c_globalVar = value; }
        }		
		
    }  
  
