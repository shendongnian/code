    class Library 
    {     
        public string Books(string title)
        {         
            return this.GetBookByName(title);
        }      
    
        public DateTime PublishingDates(string title)
        {         
            return this.GetBookByName(title).PublishingDate;   
        } 
    } 
