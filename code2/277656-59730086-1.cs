    public class Page
    {
        private string data;
        public Page()
        {
        }
        public Page(string data)
        {
            this.Data = data;
        }
        public string Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }
    }
