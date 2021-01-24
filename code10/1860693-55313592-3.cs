    public class Student
    {
        public DateTime dob { get; set; }
        public string name { get; set; }
        public string location { get; set; }
    
        public override string ToString()
        {
            return name + " - " + dob.ToString("MMM dd, yyyy")+ " - " +location;
        }
    }
