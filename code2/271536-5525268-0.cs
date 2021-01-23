    class Test
    {
        public int Prop { get; set; }
    
        public Test(int prop)
        {
            Prop = prop;
        }
    
        private Test()
        {
    
        }
    }
    
    var t = new Test
    {
        Prop = 1
    };
