    //Widget.cs
    Public class Widget
    {
      public string URL { get; set; }
      public string Category { get; set; }
    }
    //Code somewhere else..
    XDocument loaded = XDocument.Parse(xml); 
 
    IEnumerable<Widget> widgets = 
                  from x in loaded.Descendants("widget") 
                  select new Widget()
                  { 
                    URL = x.Descendants( "url" ).First().Value, 
                    Category = x.Descendants( "PortalCategoryId" ).First().Value 
                  }; 
