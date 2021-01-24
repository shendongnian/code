    public class Company
    {
        public Details details { get; set; }
        public List<Employeee> Employees { get; set; }
        // You can not initialize the Company
        // class witouth passing the company details
        public Company(Details details)
        {
            this.details = details;
        }
    }
    public class Details
    {
        public string Name { get; set; }
        public string URL { get; set; }
        // You can not initialize the details
        // without a Name and URL
        public Details(string Name, string URL)
        {
            // If the validation fails, return
            if (!Validation(Name, URL)) return;
            // Inserts the parameter
            this.Name = Name;
            this.URL = URL;
        }
        private bool Validation(string Name, string URL)
        {
            // If string is empty, return false
            if (string.IsNullOrWhiteSpace(Name)) return false;
            // If string is empty, return false
            else if (string.IsNullOrWhiteSpace(URL)) return false;
            // else return true
            else return true;
        }
    }
