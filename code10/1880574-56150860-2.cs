    public class YourViewModel
    {
            public List<FilterJSONItem> FilterJSON{ get; set; }
    }
    
    public class FilterJSONItem
    {
            public string FilterType { get; set; }
            public string FilterDescription { get; set; }
            public string OptionDescription { get; set; }
            public bool OptionSelected { get; set; }
    }
    public ActionResult Method([FromBody]YourViewModel vm)
    {
    }
