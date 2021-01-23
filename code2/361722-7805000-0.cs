    static void Main(string[] args)
    {
        List<Parameter> pList = new List<Parameter>();
        pList.Add(new Parameter("@a", "aaaa!"));
        pList.Add(new Parameter("@b", "bbbb!"));
        pList.Add(new Parameter("@c", "cccc!"));
        DoStuff(pList.ToArray());
    }
    static void DoStuff(params Parameter[] parameters){ 
        
        foreach(var p in parameters)
        {
            //do something.
        }
    }
