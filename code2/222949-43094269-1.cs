    public class Lion : Animal
        {
            private string yahoo;
    
            protected Lion(string name) : base(name)
            {
    
                this.Yahoo = "Yahoo!!!";
            }
    
            public string Yahoo
            {
                get
                {
                    return yahoo;
                }
    
                set
                {
                    yahoo = value;
                }
            }
    
            public Lion() { }
        }
