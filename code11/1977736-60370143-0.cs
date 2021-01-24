c#
// New temporary class
    public class TempClass
    {
        public List<ItemClass> ItemList { get; set; }
        public ListInfo ListInfo { get; set; }
    }
    public class ItemClass
    {
        public int Id;
        public string Name;
    }
    public class ListInfo
    {
        public int Info1 { get; set; }
        public string Info2 { get; set; }
    }
Above temp-class will hold the de-serialized object. Then use the following way to de-serialize and read the two different objects. 
c#
List<ItemClass> ItemsList = ((TempClass)JsonConvert.DeserializeObject<TempClass>(strJsom, new JsonSerializerSettings())).ItemList;
ListInfo ListInfo = ((TempClass)JsonConvert.DeserializeObject<TempClass>(strJsom, new JsonSerializerSettings())).ListInfo;
Now, you can traverse through the `ItemsList` to read each `ItemClass` from the Json. 
Hope this helps.
 
