    class StarSign
    {
        public string Name {get;set;}
    
        public DateTime StartDate {get;set;}
    
        public DateTime EndDate {get;set;}
    
        public bool CoversDate(DateTime birthday)
        {
            return birthday <= this.EndDate && birthday >= this.StartDate;
        }
    }
