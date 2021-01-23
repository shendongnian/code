    class User
    {
    
        private string name = "Suresh Dasari";
        public string Name
        {
         get
            {
                return name.ToUpper();
    
            }
    
            set
            {
           if (value == "Suresh")
                 name = value;
           }
            }
        }
