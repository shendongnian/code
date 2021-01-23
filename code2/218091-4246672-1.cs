    [XmlRoot]
    public class Stats{
      public Stats(){}
      public IList<StatsItem> Items{get;set;} 
    }
    public class StatsItem{
      public StatsItem(){}     
      public string UrlName{get;set;}
      public DateTime Date{get;set;}
    }
