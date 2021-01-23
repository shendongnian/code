       int intCount = 0;
        XmlReaderSettings objSettings = new XmlReaderSettings();
        objSettings.IgnoreWhitespace = true;
        objSettings.IgnoreComments = true;
        string booksFile = Server.MapPath("books.xml");
        using (XmlReader objReader = XmlReader.Create(booksFile, objSettings))
        {
            while (objReader.Read())
            {
                if (objReader.NodeType == XmlNodeType.Element && "Book" == objReader.LocalName)
                {
                     intCount++;
                }
                if (objReader.NodeType ==XmlNodeType.Text )
                {
                    Response.Write("<BR />" + objReader.Value);
                }
            }
        }
        Response.Write(String.Format("<BR /><BR /><BR /><b> Total {0} books.</b>", intCount));
