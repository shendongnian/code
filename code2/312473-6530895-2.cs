    public class IndexViewModel 
    {
        public PageMeta PageMeta { get; set; }
        public T Test { get; set; }
        public Q Que { get; set; }
        public IndexViewModel()
        {
            this.PageMeta = new PageMeta();
            this.Test = new T();
            this.Que = new Q();
        }
    }
