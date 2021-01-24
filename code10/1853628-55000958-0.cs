    public class Program
    {
    	public static DateTime NextTwentyNineFeb()
    	{
    		int year = DateTime.Now.Year;
    		while(true){			
    			try{
    				var target = new DateTime(year, 2, 29);
    				Console.WriteLine(target);
    				return target;
    			}
    			catch
    			{
    				year++;
    			}
    		}
    	}
    }
