    class Library 
    {     
        public string Books(string title)
        {         
            get
            {
                return this.GetBookByName(string title);
            }     
        }      
    
        public DateTime PublishingDates(string title)
        {         
            get
            {
                return this.GetBookByName(string title).PublishingDate;
            }     
        } 
    } 
