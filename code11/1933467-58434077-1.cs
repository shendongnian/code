    var doc = XDocument.Parse(xml);
    foreach (XElement module in doc.Root.Elements())
    {
        foreach (XElement letterGroup in module.Elements())
        {
            foreach (XElement letter in letterGroup.Elements())
            {
                switch(letter.Name.LocalName)
                {
                    case "F":
                        MessageBox.Show("IP: " + letter.Value);
                        break;
                    case "G":
                        MessageBox.Show("Port: " + letter.Value);
                        break;
                    }
                }
            }
        }
    }
