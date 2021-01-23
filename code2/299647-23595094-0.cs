    while (reader.Read())
    {
       switch (reader.NodeType)
       {
           case XmlNodeType.Element:
           {
               if (reader.Name == "CharCode")
               {
                   switch (reader.ReadInnerXml())
                   {
                       case "EUR":
                       {
                            reader.ReadToNextSibling("Value");
                            label4.Text = reader.ReadInnerXml();
                       }
                       break;
                       case "USD":
                       {
                            reader.ReadToNextSibling("Value");
                            label3.Text = reader.ReadInnerXml();
                       }
                       break;
                       case "RUB":
                       {
                            reader.ReadToNextSibling("Value");
                            label5.Text = reader.ReadInnerXml();
                       }
                       break;
                       case "RON":
                       {
                            reader.ReadToNextSibling("Value");
                            label6.Text = reader.ReadInnerXml();
                       }
                       break;
                   }
               }
            }
            break;
        }
    }
