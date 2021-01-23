            static void Main(string[] args)
        {
            string s = "<TestXMl Var1=\"000\" Var2=\"000\" Var3=\"01\"><var4>testdata</var4><var5>testdata</var5><var6>testdata</var6><DeeperLevel><var7>testdata</var7><var8>testdata</var8><var9>testdata</var9><var10>testdata</var10></DeeperLevel></TestXMl> ";
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(s);
            string var1 = xDoc.SelectSingleNode("/TestXMl/attribute::Var1").Value;
            Console.WriteLine(var1);
            string var2 = xDoc.SelectSingleNode("/TestXMl/attribute::Var2").Value;
            Console.WriteLine(var2);
            string var3 = xDoc.SelectSingleNode("/TestXMl/attribute::Var3").Value;
            Console.WriteLine(var3);
            string var4 = xDoc.SelectSingleNode("/TestXMl/var4").InnerText;
            Console.WriteLine(var4);
            string var5 = xDoc.SelectSingleNode("/TestXMl/var5").InnerText;
            Console.WriteLine(var5);
            string var6 = xDoc.SelectSingleNode("/TestXMl/var6").InnerText;
            Console.WriteLine(var6);
            string var7 = xDoc.SelectSingleNode("/TestXMl/DeeperLevel/var7").InnerText;
            Console.WriteLine(var7);
            string var8 = xDoc.SelectSingleNode("/TestXMl/DeeperLevel/var8").InnerText;
            Console.WriteLine(var8);
            string var9 = xDoc.SelectSingleNode("/TestXMl/DeeperLevel/var9").InnerText;
            Console.WriteLine(var9);
            string var10 = xDoc.SelectSingleNode("/TestXMl/DeeperLevel/var10").InnerText;
            Console.WriteLine(var10);
        }
