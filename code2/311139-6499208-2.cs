    static class ID
    {
        public const int Unassigned = -1;
    }
    class MyModel
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool? IsAwesome { get; set; }
    
        Model () 
        {
            // you may use "default" constants...
            Id = ID.Unassigned;
        }
        // you may use optional parameters or overloads
        public MyModel (string title,
            DateTime created = DateTime.Now, // default values may be concrete 
            bool? isAwesome = null)          // or nullable as well
            : this ()                        // and you can chain-call constructors!
        {
            Title = title ?? "<no title>";   // you don't always want null to come through
            CreatedDate = created;     
            IsAwesome = isAwesome;    
        }
    }
    
    // Possible usages:
    var model = new MyModel ("Hello", new DateTime (2001, 1, 1));
    var model = new MyModel ("world", isAwesome: true);
    var model = new MyModel (null) {
        IsActive = true
    };
