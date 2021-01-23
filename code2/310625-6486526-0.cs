    public static void Append(string filename, string firstName)
    {
        var contact = new XElement("contact", new XElement("firstName", firstName));
        var doc = new XDocument();
        if (File.Exists(filename))
        {
            doc = XDocument.Load(filename);
            doc.Element("contacts").Add(contact);
        }
        else
        {
            doc = new XDocument(new XElement("contacts", contact));
        }
        doc.Save(filename);
    }
