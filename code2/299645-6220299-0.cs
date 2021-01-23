            StringReader myUrl = new StringReader(@"<?xml version=""1.0"" encoding=""UTF-8""?>
    <data>
      <p>Here is some <b>data</b></p>
    </data>");
            using (XmlReader reader = XmlReader.Create(myUrl))
            {
                while (reader.Read())
                {
                    if (reader.Name == "p")
                    {
                        // I want to get all the TEXT contents from the this node
                        Console.WriteLine(reader.ReadInnerXml());
                    }
                }
            }
