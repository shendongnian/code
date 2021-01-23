    public class AdminVATViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public class MyViewModel
    {
        public string SelectedVAT { get; set; }
        public IEnumerable<AdminVATViewModel> ListVAT { get; set; }
    }
