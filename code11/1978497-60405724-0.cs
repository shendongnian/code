      public class Doctor
    {
        public Doctor(string firstName , string LastName, string address , string isAvailable , ICollection<Center> centers)
        {
            //Check for the avaiblity
            IsAvailable(string address);
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public bool? IsAvailable { get; private set; }
        public virtual ICollection<Center> Centers { get; private set; }
    }
    
