    public class ValueGetter<T> where T : Control
    {
        public List<Func<T, string>> Operations { get; set; }
    
        public ValueGetter()
        {
            this.Operations = new List<Func<T, string>>();
        }
    
        public void Map(Func<T, string> valueGetter)
        {
            this.Operations.Add(valueGetter);
        }
    }
