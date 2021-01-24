	public class Company {
		public Details details { get; set; }
		public List<Employeee> Employees { get; set; }
		// You can not initialize the Company
		// class witouth passing the company details
		public Company(Details details) { 
			this.details = details;
		}
	}
	public class Details {
		public string Name { get; set; }
		public string URL { get; set; }
		// You can not initialize the details
		// without a Name and URL
		public Details(string Name, string URL) {
            // <-- Insert validation of name and URL
            this.Name = Name;
			this.URL = URL;
		}
	}
