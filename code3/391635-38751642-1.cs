        bool somecondition = true;
        public DateTime? ResolveDate()
        {
            DateTime? date = null;
            if (somecondition == true)
            {
                date = DateTime.Now;
                return DateTime.Now;
            }
            else return date;
        }
    
