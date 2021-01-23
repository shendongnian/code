    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;
    using System.IO;
    
    namespace Test
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string url = "www.somewhere.com/files/feed/list.zip";		
    			string fileName = @"C:\list.zip";
    
    			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    			request.Timeout = 5000;
    
    			try
    			{
    				using (WebResponse response = (HttpWebResponse)request.GetResponse())
    				{
    					using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
    					{
    						byte[] bytes = ReadFully(response.GetResponseStream());
    
    						stream.Write(bytes, 0, bytes.Length);
    					}
    				}
    			}
    			catch (WebException)
    			{
    				Console.WriteLine("Error Occured");
    			}
    		}
    
    		public static byte[] ReadFully(Stream input)
    		{
    			byte[] buffer = new byte[16 * 1024];
    			using (MemoryStream ms = new MemoryStream())
    			{
    				int read;
    				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
    				{
    					ms.Write(buffer, 0, read);
    				}
    				return ms.ToArray();
    			}
    		}
    	}
    }
