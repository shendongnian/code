    public class Item
    {
        public List<string> MCS { get; set; } = new List<string>();
    } 
    public class PermitedItem
    {
        public Item read {get; set;}
        public Item update {get; set;}
        public Item delete {get; set;}
    }
    public class MyResponse
    {
        public List<PermittedItem> Permitted = new List<PermittedItems>();
    }
