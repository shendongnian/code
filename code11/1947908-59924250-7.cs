    class Klas
    {
        public string Klascode { get; set; }
        public string Klasnaam { get; set; }
        public IList<Student> Students { get; set; }
    	
    	// just declare properties, no constructor! A true POCO class
    	
    	// just a heads up, but not important for this example:
    	// you can have more than one constructor (it's called overloading)
    }
