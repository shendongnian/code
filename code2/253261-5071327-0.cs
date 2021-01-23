    using System;
    using System.Text.RegularExpressions;
     
    public class Test
    {
            public static void Main()
            {
                    String s = "var rawItemInfo={\"stock\":\"In stock. Limit 5 per customer.\",\"shipping\":\"$19.99 Shipping\",\"finalPrice\":\"139.99\",\"itemInfo\":\"<div class=\"grpPricing\"";
                    Console.WriteLine("Testing '{0}'", s);
                    test(s);
     
                    Console.WriteLine();
     
                    s = "var rawItemInfo={\"stock\":\"In stock. Limit 5 per customer.\",\"shipping\":\"free Shipping\",\"finalPrice\":\"139.99\",\"itemInfo\":\"<div class=\"grpPricing\"";
                    Console.WriteLine("Testing '{0}'", s);
                    test(s);
            }
     
            public static void test(String s)
            {
                    String p = "stock\":\"(.*?)\",\".*?shipping\":\"(.*?)\",\".*?finalPrice\":\"(.*?)\"";
                    // modification
                    p = "stock\":\"(.*?)\",\".*?shipping\":\"(\\$([\\d\\.]+)|(free))\\s?(.*?)\",\".*?finalPrice\":\"(.*?)\"";
     
                    Regex regex = new Regex(p);
                    var data = regex.Match(s);
     
                    for (Int32 i = 0; i < data.Groups.Count; i++)
                            Console.WriteLine("{0}. {1}", i, data.Groups[i].Value);
     
                    Console.WriteLine("Price is {0}", data.Groups[2].Value.Equals("free")?"FREE":data.Groups[3].Value);
            }
    }
