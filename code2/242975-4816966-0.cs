    public class IndexViewModel
    {
        public string MainNav { get; set; }
        public string SubNav { get; set; }
        public IndexViewModel(string mainnav, string subnav)
        {
            this.MainNav = mainnav;
            this.SubNav = subnav;
        }
    }
