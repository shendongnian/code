    using System;
    using Microsoft.SharePoint.Client;
    
    class Program
    {
        static void Main()
        {
            ClientContext clientContext = new ClientContext("http://intranet.contoso.com");
            List list = clientContext.Web.Lists.GetByTitle("Announcements");
            CamlQuery camlQuery = new CamlQuery();
            camlQuery.ViewXml = "<View/>";
            ListItemCollection listItems = list.GetItems(camlQuery);
            clientContext.Load(list);clientContext.Load(listItems);
            clientContext.ExecuteQuery();
            foreach (ListItem listItem in listItems)
                Console.WriteLine("Id: {0} Title: {1}", listItem.Id, oListItem["Title"]);
        }
    }
