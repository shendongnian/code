       var cfgIn = new ConfigWrapper{ "item1", "item2", "item3" };
       var ds = new DataContractSerializer(typeof(ConfigWrapper));
       string fileContent = null;
       
       using (var ms = new MemoryStream())
       {
            ds.WriteObject(ms, cfgIn);
            fileContent = Encoding.UTF8.GetString(ms.ToArray());
            Console.WriteLine (fileContent);
       }
       // yields: <collection xmlns:i="http://www.w3.org/2001/XMLSchema-instance"><item>item1</item><item>item2</item><item>item3</item></collection>
       
       ConfigWrapper cfgOut = null;
       using (var sr = new StringReader(fileContent))
       {
            using(var xr = XmlReader.Create(sr))
            {
                cfgOut = ds.ReadObject(xr) as ConfigWrapper;
                // cfgOut.Dump(); //view in LinqPad
                if(cfgOut != null)
                    // yields 'item2'
                    Console.WriteLine (cfgOut[1]);
            }
       }
