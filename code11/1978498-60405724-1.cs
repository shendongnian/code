      public class Doctor
    {
        public Doctor(string firstName , string LastName, string address , string isAvailable , ICollection<Center> centers)
        {
            //Check for the avaiblity
            IsAvailable(string address);
             // after checking the data assign in it 
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.IsAvailable = isAvailable;
            this.Centers = centers;
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public bool? IsAvailable { get; private set; }
        public virtual ICollection<Center> Centers { get; private set; }
    }
    
