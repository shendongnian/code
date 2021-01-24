    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		        int block = 11;
                    int size = 0;
                    //string content = "zQzhPeWFXZG:5:3:2tGTGlvmQzTm9UTU91NG9DNndySERrOEsveFpMQ3ExUGlo"; //this key gets normally decrypted with aes but that is not the problem
    		        string content = "zQzhPeWFXZG532tGTGlvmQzTm9UTU91NG9DNndySERrOEsveFpMQ3ExUGlo"; //this key gets normally decrypted with aes but that is not the problem
                    string[] split =content.Split(':');
    		        foreach(var item in split)
    				{
    					Console.WriteLine(item);
    				}
                    block = Convert.ToInt32(content.Split(':')[2]);
                    size = Convert.ToInt32(content.Split(':')[1]);
                    content = content.Split(':')[0];
    				Console.WriteLine(block);
    		        Console.WriteLine(size);
    		        Console.WriteLine(content);
    	}
    }
