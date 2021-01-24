        private string text;
        public string Text
        {
            get
            {
                if (text== null)
                    return "default value";
                else
                    return this.text;
            }
            set { this.text= value; }
 
        }
