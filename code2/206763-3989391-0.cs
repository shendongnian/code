    UTF7Encoding allowOptionals = new UTF7Encoding(true);
    using (var sw = new StreamWriter(@"D:\toto.csv.copy", false, allowOptionals))
    {
        using (var sr = new StreamReader(@"D:\toto.csv", Encoding.UTF7))
        {
            string line;
            while (null != (line = sr.ReadLine()))
            {
                sw.WriteLine(line);
            }
        }
    } 
