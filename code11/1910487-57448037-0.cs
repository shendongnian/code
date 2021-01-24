    public class Item : IComparable {
      public string Code { get; set; }
      public string Description { get; set; }
      public int Count { get; set; }
      public bool OnOrder { get; set; }
      public Item(string code, string description, int count, bool onOrder) {
        Code = code;
        Description = description;
        Count = count;
        OnOrder = onOrder;
      }
      public int CompareTo(object obj) {
        Item that = (Item)obj;
        return Count.CompareTo(that.Count);
      } 
    }
