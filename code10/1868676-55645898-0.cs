    public Dictionary<string, object> GetPendingEmployeeItem(int itemId)
        {
            var list = _app.Sharepoint.Web.Lists.GetByTitle("New Employee");
            var query = new CamlQuery();
            query.ViewXml = "<View></View>";
            var collection = list.GetItems(query);
            _app.Sharepoint.Load(collection);
            _app.Sharepoint.ExecuteQuery();
            
            return collection.First(item => item.Id.Equals(itemId)).FieldValues;
        }
