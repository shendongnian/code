    public class StoreListView
    {
        public void StoreToDisk(string path, List<ItemDataHolder> list)
        {
            
            string theListInJsonFormat = JsonConvert.SerializeObject(list);
    
            File.WriteAllText(path, theListInJsonFormat);
        }
    }
    
    public class ItemDataHolder
    {
        public string SomeValuesYouWantToSave { get; set; }
        public bool IsChecked { get; set; }
    }
