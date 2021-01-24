public static SPListItemCollection GetCollection()
        {
            string listName = 'Your List Name';
            string queryStr = "<Where><Eq><FieldRef Name='Title''/><Value Type='Text'>" + YourValue + "</Value></Eq></Where><OrderBy><FieldRef Name='ID' Ascending='FALSE'/></OrderBy>";
            SPListItemCollection oCollection = GetListItemCollectionByQuery(listName, queryStr);
            return oCollection;
        }
        public static SPListItemCollection GetListItemCollectionByQuery(string ListName, string queryText)
        {
            SPListItemCollection spListItemCollection = null;
            string webUrl = Your Site URL;
            try
            {
                using (SPSite oSPsite = new SPSite(webUrl))
                {
                    using (SPWeb oSPWeb = oSPsite.OpenWeb())
                    {
                        string listName = ListName;
                        SPList spList = oSPWeb.Lists[listName];
                        if (spList != null)
                        {
                            SPQuery spQuery = new SPQuery();
                            spQuery.Query = queryText;
                            spListItemCollection = spList.GetItems(spQuery);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return spListItemCollection;
        }
Also, you need to check this [Get DataTable][1]
  [1]: https://sharepoint.stackexchange.com/questions/180374/difference-between-splist-getdatatable-and-splist-getitemsspquery-getdatatable
I hope it may help :)
