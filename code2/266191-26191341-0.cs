    using System;
    using CurlSharp;
    
    internal class EasyGet
    {
        public static void Main(String[] args)
        {
            Curl.GlobalInit(CurlInitFlag.All);
    
            try
            {
                using (var easy = new CurlEasy())
                {
                    easy.Url = "http://www.google.com/";
                    easy.WriteFunction = OnWriteData;
                    easy.Perform();
                }
            }
            finally
            {
                Curl.GlobalCleanup();
            }   
        }
    
        public static Int32 OnWriteData(Byte[] buf, Int32 size, Int32 nmemb, Object extraData)
        {
            Console.Write(Encoding.UTF8.GetString(buf));
            return size*nmemb;
        }
    }
