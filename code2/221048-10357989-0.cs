        private DateTime _dt;
        
        [LocalizedValidDateAttribute("Resources.DateTimeOffsetModel.App_GlobalResources", "TimePart_Invalid")]   
        public string DateTimeString
        {
            get { return _dt.ToString(); }
            set { DateTime.TryParse(value, out _dt); }
        }    
