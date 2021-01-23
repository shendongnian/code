        //Load xml
        XDocument xdoc = XDocument.Load(@"A:\Users\Tono\Desktop\SaveContentFromCache\SaveContentFromCache\FileSignatures.xml");
        //Run query
        var files = from elements in xdoc.Descendants("File")
                   select new { 
                       Children = elements.Descendants()
                   };
        //Loop through results
        foreach (var elem in files)
        {
            FileSignature f = new FileSignature();
            foreach (var lv2 in elem.Children)
            {
                if (lv2.Name.ToString().ToUpper().Contains("SIGNATURE"))
                    f.signature = lv2.Value.ToString();
                else if (lv2.Name.ToString().ToUpper().Contains("DESCRIPTION"))
                    f.description = lv2.Value.ToString();
                else if (lv2.Name.ToString().ToUpper().Contains("EXTENSION"))
                    f.extensions = lv2.Value.ToString().Split('|');              
            }
            Files.Add(f);
        }
