    public abstract class Base
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetName(value); }
        }
        
        protected abstract void SetName(string value);
    }
