    class Library 
    {     
        public string Books(string title)
        {         
            return this.GetBookByName(string title);
        }      
    
        public DateTime PublishingDates(string title)
        {         
            return this.GetBookByName(string title).PublishingDate;   
        } 
    } 
