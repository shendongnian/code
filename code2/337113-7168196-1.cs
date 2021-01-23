    public class InfoCount
    {
        private string _info = "";
        private int _count = 0;
        public string Info {
                get { return _info; }
                set { _info = value; }
        }
        public int Count {
                get { return _count; }
                set { _count = value; }
        }
        public InfoCount (string Info, int Count)
        {
            this.Info = Info;
            this.Count = Count;
        }
    }
