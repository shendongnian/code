    static void Main(string[] args)
    {
        List<Action> actionList = new List<Action>();
        if (true)
        {
            actionList.Add(new Action(DoSomething));
        }
        // etc.
        foreach (Action a in actionList)
        {
            a();
        }
    }
    static void DoSomething()
    {
        // Code to do something.
    }
