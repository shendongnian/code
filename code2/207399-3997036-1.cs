    class ReadableText
    {
        private string text = string.Empty;
        public ReadableText(string value)
        {
            text = value;
        }
        public string Text
        {
            get { return text; }
        }
    }          
          
    class WriteableText : ReadableText
    {
        public WriteableText(string value):base(value)
        {
            
        }
        public string Text
        {
            set
            {
                OnTextSet(value);
            }
            get
            {
                return base.Text;
            }
        }
        public void SetText(string value)
        {
            Text = value;
            // in reality we'd NotifyPropertyChanged in here       
        }
        public void OnTextSet(string value)
        {
            // call out to business logic here, validation, etc.       
            SetText(value);
        }
    }     
     
