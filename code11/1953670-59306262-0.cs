    public class Config
    {
        public Config()
        {
            this.MyProperty2 = new List<int> { 4, 5, 6 };
        }
        public string MyProperty1 { get; set; }
        public List<int> MyProperty2 {
            get {
                return this.MyProperty2;
            } 
            set {
                if(this.MyProperty2.Count > 0)
                {
                    this.MyProperty2.Clear();
                    this.MyProperty2 = value;
                }
            } 
        }
    }
