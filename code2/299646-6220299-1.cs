            StringReader myUrl = new StringReader(@"<?xml version=""1.0"" encoding=""UTF-8""?>
    <data>
      <p>Here is some <b>data</b></p>
    </data>");
            StringBuilder myVar = new StringBuilder();
            using (XmlReader reader = XmlReader.Create(myUrl))
            {
                while (reader.Read())
                {
                    if (reader.Name == "p")
                    {
                        XmlReader pReader = reader.ReadSubtree();
                        while (pReader.Read())
                        {
                            if (pReader.NodeType == XmlNodeType.Text)
                            {
                                myVar.Append(pReader.Value);
                            }
                        }
                    }
                }
            }
            Console.WriteLine(myVar.ToString());
