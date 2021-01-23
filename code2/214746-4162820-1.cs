    public class Bob
    {
        public String Surname { get; set; }
    
        protected Bob()
        { }
    
        public Bob(string surname)
        {
            Surname = surname;
        }
    }
    
    public class Fred : Bob
    {
        public Fred()
            : base()
        {
        }
    }
