    public static ICollection<Action> ProcessInvocationInput(int[] val)
    {
        var actions = new List<Action>();
        foreach (int i in val)
        {
            switch (i)
            {
                case 1: actions.Add(PrintInt);
                case 2: actions.Add(PrintString);
            }
        }
        return actions;
    }
    ...
    foreach (var action in ProcessInvocationInput(input))
    {
        action();
    } 
