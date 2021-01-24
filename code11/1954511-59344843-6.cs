        private string _value;
    
        [Parameter]
        public string Value
        {
            get { return _value ?? string.Empty; }
            set
            {
                if (Value != value)
                {
                   _value = value;
                   
                }
              }
         }
     
    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }
