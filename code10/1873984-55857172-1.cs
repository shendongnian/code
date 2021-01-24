    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(next_Version("1.2.3.4"));
    		Console.WriteLine(next_Version("11.2.3"));
    	}
    	public static string next_Version(string version)
        {
    		string[] a = version.Split('.');
    		int x = a.Length;
    		int carrying = 1;
    		while(x>0){
    			
    			int number = Convert.ToInt32(a[x-1]);
    			
    			if(Convert.ToString(number+carrying).Length > Convert.ToString(number).Length){
				string zeroes = "";
				foreach(char c in Convert.ToString(number)){
					zeroes += "0";
				}
				a[x-1] = zeroes;
				carrying = 1;
			    }else{
    				a[x-1] = Convert.ToString(number+carrying);
    				carrying = 0;
    				}
    			x--;
    		}
    		String result = "";
    		foreach(string s in a){
    			result+=s+".";
    		}
    
            return result.TrimEnd('.');
        }
    }
