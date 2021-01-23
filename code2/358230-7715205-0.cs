    public class TestModel {
        public TestModel(IEnumerable<string> colors)
        {
            AvailableColors = colors.Select(c => new SelectListItem{Text=c, Value = c});
        }
        
        public String Color { get; set; }
        IEnumerable<SelectListItem> AvailableColors {get;}
    }
