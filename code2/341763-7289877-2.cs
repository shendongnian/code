    using System;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            string oracle = "329DD817216CD6429B989F5201288DBF";
            string dotNet = "17D89D326C2142D69B989F5201288DBF";
            
            Console.WriteLine(oracle == DotNetToOracle(dotNet));
            Console.WriteLine(dotNet == OracleToDotNet(oracle));
        }
        
        static string OracleToDotNet(string text)
        {
            byte[] bytes = ParseHex(text);
            Guid guid = new Guid(bytes);
            return guid.ToString("N").ToUpperInvariant();
        }
        
        static string DotNetToOracle(string text)
        {
            Guid guid = new Guid(text);
            return BitConverter.ToString(guid.ToByteArray()).Replace("-", "");
        }
        
        static byte[] ParseHex(string text)
        {
            // Not the most efficient code in the world, but
            // it works...
            byte[] ret = new byte[text.Length / 2];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
            }
            return ret;
        }
        
    }
