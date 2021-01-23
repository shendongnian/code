    public class IdName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
       string jsonStringSingle = "{'Id': 1, 'Name':'Thulasi Ram.S'}".Replace("'", "\"");
       var entity = new JavaScriptSerializer().Deserialize<IdName>(jsonStringSingle);
       string jsonStringCollection = "[{'Id': 2, 'Name':'Thulasi Ram.S'},{'Id': 2, 'Name':'Raja Ram.S'},{'Id': 3, 'Name':'Ram.S'}]".Replace("'", "\"");
       var collection = new JavaScriptSerializer().Deserialize<IEnumerable<IdName>>(jsonStringCollection);
