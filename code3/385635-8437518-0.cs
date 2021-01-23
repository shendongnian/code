    public static void CallTestDelegate()
    {
    	TestDelegate((d, s) => d.Height = Single.Parse(s));
    }
    
    public static void TestDelegate(Action<RectangleF, string> action)
    {
    	Dictionary<String, MulticastDelegate> dict = new Dictionary<string, MulticastDelegate>();
    	dict.Add("a1", action);
    	Action<RectangleF, string> action2 = (d, s) => d.Width = Single.Parse(s);
    	dict.Add("a2", action2);
    
    	var a1 = (Action<RectangleF, string>)dict["a1"];
    	a1(new RectangleF(), "15");
    }
