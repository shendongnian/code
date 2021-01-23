    public class SampleControl
    {
        public int A { get; set; }
        public int B { get; set; }
        public Collection<int> MysteryCollection
        {
            get
            {
                Collection<int> ints = new Collection<int>();
                //........
                return ints;
            }
        }
    }
