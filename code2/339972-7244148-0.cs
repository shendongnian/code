    public void EditItem(Item item, string xml)
    {
        Data = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Items/" + xml + ".xml"));
        XElement node = Data.Root.Elements("item").Where(i => (string)i.Element("ID") == item.ID).FirstOrDefault();
        if (node != null)
        {
            node.SetElementValue("ID", item.ID);
            node.SetElementValue("Name", item.Name);
            node.SetElementValue("Type", item.Type);
            node.SetElementValue("Kr", item.Kr);
            node.SetElementValue("Euro", item.Euro);
            Data.Save(HttpContext.Current.Server.MapPath("~/App_Data/Tables/" + xml + ".xml"));
        }
    }
