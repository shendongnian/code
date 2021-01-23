    using System.Collections.Generic;
    
    namespace YieldReturn
    {
    	class Program
    	{
    		public static void Main(string[] args)
    		{
    			MyClass mc = new MyClass();
    			IEnumerator<int> enu = mc.GetHour().GetEnumerator();
    			enu.MoveNext();
    			int hour = enu.Current;
    			enu.MoveNext();
    			int min = enu.Current;
    			Console.WriteLine("Hour {0} min {1}", hour, min);
    			Console.ReadKey(true);
    		}
    	}
    
    	class MyClass
        {
    		DateTime dt;
    		
    		public MyClass()
    		{
    			dt = DateTime.Now;
    		}
    		public IEnumerable<int> GetHour()
            {
    			int hour = dt.Hour;
    			int minute = dt.Minute;
    	        yield return hour;
            	yield return minute;
            }
        }
    }
