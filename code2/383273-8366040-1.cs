            XmlDocument doc = new XmlDocument();
            doc.Load(spath);
            foreach (XmlElement xe in doc.DocumentElement.SelectNodes("/Snippets/Snippet"))
            {
                string sName = xe.Attributes["name"].Value;
                string sCode = xe.SelectSingleNode("/SnippetCode").InnerText;
                listBox1.Items.Add(snippetName);
                snippets.Add(sCode);
            }
