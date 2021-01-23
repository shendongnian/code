    public class MyViewModel 
    {
        public string SomeNonFormDisplayValue { get; set; }
        public bool AnotherDisplayOnlyValue { get; set; }
        public IEnumerable<Tuple<int, string>> SelectionListItems { get; set; }
        public MyViewsForm Form { get; set; }
    }
    public class MyViewsForm
    {
        public string EditableProperty { get; set; }
        public int SelectionListItemId { get; set; }
    }
