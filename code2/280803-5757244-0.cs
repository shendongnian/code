    static void Main(string[] args)
    {
      XDocument xml =
        XDocument.Load(
          @"Path to your xml");
      var q = from x in xml.Descendants("item")
              orderby Convert.ToInt32(x.Attribute("id").Value) ascending
              select new Calendar
                       {
                         Name = x.Elements("Name").Select(a => a.Value).ToList<String>(),
                         Date = x.Elements("Date").Select(a => a.Value).ToList<String>()
                       };
      List<Calendar> calendars = q.ToList<Calendar>();
    }
    public class Calendar
    {
      public List<String> Name { get; set; }
      public List<String> Date { get; set; }  
    } 
  }
