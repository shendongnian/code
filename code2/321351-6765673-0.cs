    public void DoSomething(IEnumerable<string> list, params Action<string>[] actions)
    {
        foreach (var item in list)
        {
            for(int i =0; i < actions.Count; i++)
            {
               actions[i](item);
            }
        }
    }
