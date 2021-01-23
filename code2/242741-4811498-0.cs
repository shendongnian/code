    public  class  Book
    {
        public event EventHandler<EventArgs> Modified;
        public string Title
        {
            get { return Title; }
            set
            {
                Title = value;
                Modified(this, new EventArgs());
            }
        }
    }
