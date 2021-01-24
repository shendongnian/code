    void Main()
    {
    	 SomeTypes s = new SomeTypes();
    	s.type1 = "asdsad";
    	s.type2 = "damn";
    	s.type3 = "damn1";
    	s.type4 = "damn2";
    	
    	var t = typeof(SomeTypes).GetFields(); // get all fields
    	
    	Random r = new Random();
    	int rInt = r.Next(0, t.Length); // create a random number in range of property count
    	
    	var res = s.GetType().GetField(t[rInt].Name); // get random property name
    	
    	var randomValue = res.GetValue(s);//get that property value
    }
    
    public struct SomeTypes
    {
        public string type1;
        public string type2;
        public string type3;
        public string type4;
    }
