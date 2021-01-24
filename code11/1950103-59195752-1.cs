    public class resultRetrieveWIP
    {
        public List<wip> wips { get; set; }
        [ComVisible(true)]
        public IEnumerable GetWipsCOM() => wips;
    }
