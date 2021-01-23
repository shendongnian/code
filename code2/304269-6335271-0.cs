    public class ABC
    {
        public IList<TextFillerDetail> TextFillerDetails { get; private set }
        public ABC() : this(0)
        {
        }
        public ABC(int count)
        {
            TextFIllerDetails = Enumerable.Range(0,count)
                                          .Select(x => new TextFillerDetail())
                                          .ToList();
        }
    }
