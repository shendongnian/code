        private string _textBlockText;
        public string TextBlockText
        {
            get
            {
                if(string.IsNullOrEmpty(_textBlockText))
                {
                    return "No Data";
                }
                return _textBlockText;
            }
            set
            {
                _textBlockText = value;
            }
        }
