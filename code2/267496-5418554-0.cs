    public class PublicationsListViewModel
    {
        public IList<Publication> Publications { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public String CurrentCategory { get; set; }
        public Dictionary<String, String> SelectedItems { get; set; }
    }
