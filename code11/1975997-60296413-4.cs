    XmlSerializer serializer = new XmlSerializer(typeof(Type));
    string xml = File.ReadAllText("XMLFile3.xml");
    using (TextReader reader = new StringReader(xml))
    {
        var results = (Type)serializer.Deserialize(reader);
        foreach (var item in results.Loop)
        {
            Console.WriteLine($"{item.LoopId} {item.Name}");
            if (item.PER != null)
            {
                Console.WriteLine($"PER:{Regex.Replace(item.PER.PER01, @"\s+", "")}-{Regex.Replace(item.PER.PER02, @"\s+", "")}-{Regex.Replace(item.PER.PER03, @"\s+", "")}-{Regex.Replace(item.PER.PER04, @"\s+", "")}");
            }                      
    
            if (item.NM1 != null)
            {
                Console.WriteLine($"NM1:{Regex.Replace(item.NM1.NM101, @"\s+", "")}-{Regex.Replace(item.NM1.NM102, @"\s+", "")}");
            }
    
            if (item.LM != null)
            {
                Console.WriteLine($"LM:{Regex.Replace(item.LM.LM01, @"\s+", "")}-{Regex.Replace(item.LM.LM02, @"\s+", "")}");
            }
        }
    }
