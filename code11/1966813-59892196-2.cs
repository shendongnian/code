    Employee{
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public List<Hobby> Hobbies{get;set;}   
    }
    
    Hobby{
        public string HobbyName{get;set;}
        public string HobbyCode{get;set;}
        public bool IsSelected{get;set;}
    }
