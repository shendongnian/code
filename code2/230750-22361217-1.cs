       var itemsList = new List<string>{"item1", "item2", "item3"};
       var cfgIn = new ConfigWrapper{ Items = itemsList };
       var xs = new XmlSerializer(typeof(ConfigWrapper));
       string fileContent = null;
       
       using (var sw = new StringWriter())
       {
            xs.Serialize(sw, cfgIn);
            fileContent = sw.ToString();
            Console.WriteLine (fileContent);
       }
        
       ConfigWrapper cfgOut = null;
       using (var sr = new StringReader(fileContent))
       {
            cfgOut = xs.Deserialize(sr) as ConfigWrapper;
            // cfgOut.Dump(); //view in LinqPad
            if(cfgOut != null)
                // yields 'item2'
                Console.WriteLine (cfgOut.Items[1]);
       }
