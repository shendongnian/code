        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var serverManager = new ServerManager())
            {
                var config = serverManager.GetWebConfiguration("WebForm48", "mycustomfolder");
                var appSettings = config.GetSection("appSettings");
                var collection = appSettings.GetCollection();
                var elem = collection.CreateElement("add");
                elem.SetAttributeValue("key", "createdBy");
                elem.SetAttributeValue("value", "me");
                collection.Add(elem);
                serverManager.CommitChanges();
            }        
        }
