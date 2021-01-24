    public static void Main()
    	{
    		
    		try
    		{
    		var fromDt=DateTime.Now.AddDays(1);
    		var toDt=fromDt.AddDays(7);
    	var datas=DatsOnInterval(fromDt,toDt);
    			foreach(var x in datas)
    			{
    				Console.WriteLine(x);
    			}
    			
    		}
    		catch(Exception ex)
    		{
    			Console.WriteLine(ex.Message);
    		}
    	}
