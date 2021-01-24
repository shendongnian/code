            string xmlFilePath = @"C:\Users\codroipomad\Desktop\slave\Test.xml";
            XDocument xdoc = XDocument.Load(xmlFilePath);
            XNamespace ns = "http://www.fruitauthority.fake";
            var elBanana = xdoc.Descendants()?.Elements(ns + "FruitName")?.Where(x => x.Value == "Banana")?.Ancestors(ns + "Fruit");
            foreach (var item in elBanana)
            {
                var elColor = item.Elements(ns + "FruitColor").FirstOrDefault();
                //check se il file esiste,se non esiste lo crea
                if (!File.Exists(xmlFilePath))
                    File.Create(xmlFilePath).Dispose();
                if (elColor != null)
                {
                    elColor.Value = "YELLOW";
                }
            }
            xdoc.Save(xmlFilePath);
