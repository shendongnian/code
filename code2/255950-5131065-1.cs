    public class MyItem
    {
      public decimal Weight {get;set;}
      public decimal Height {get;set;}
      public DateTime TheDate {get;set;}
    } 
    List<MyItem> myItems = new List<MyItems>();
    var mySortedList = myItems.OrderBy(p => p.Weight);
