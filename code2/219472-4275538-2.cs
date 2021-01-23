        string xml;
        using (var ms = new MemoryStream()) { 
            using(var tw = new StreamWriter(ms, Encoding.UTF8))
            {
                el.Save(tw);            
            }
            xml = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
        }
