    // create a class, if you want, 
    // or you could either use a string or int for zips
    public Class Zip
    {
        // this is the standard zip
        // ex: 90210
        public string First {get; set;}
        // this is the optional, extra four-digits
        // ex: Chicago, IL 60612-0344
        public string PlusFour {get; set;}
    }
    ....
    // declare your variable, somewhere in your class
    private Dictionary<Zip, string> zipLookup;    
    // in your constructor, or some other method, initialize
    public TestConstructor()
    {
        zipLookup = new Dictionary<Zip, string>();
        // fill up the values
        zipLookup.Add(new KeyValuePair<Zip, string>(90210, "Beverly Hills");
        ....
    }
    private void Test()
    {
        // use your dictionary
        ....
    }     
