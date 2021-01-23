    using System;
    using SeasideResearch.LibCurlNet;
    
    namespace Sample
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
    
    			Easy easy = new Easy();
    			Easy.WriteFunction wf = MyWriteFunction;
    			easy.SetOpt(CURLoption.CURLOPT_URL, "http://google.com/index.html");
    			easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
    			easy.Perform();
    			easy.Cleanup();
    			Console.WriteLine("Press any key...");
    			Console.ReadKey();
    		}
    
    		private static int MyWriteFunction(byte[] buf, int size, int nmemb, Object extraData)
    		{
    			foreach (byte b in buf)
    				Console.Write((char)b);
    
    			return buf.Length;
    		}
    	}
    }
