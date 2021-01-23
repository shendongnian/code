    class NewString
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    
    public NewString Test()
    {
        return ( new NewString() { ID = 5, Name = "Dave" } );
    }
:)
