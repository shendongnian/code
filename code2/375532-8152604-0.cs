    public void Run(params Action<int>[] actions)
    {      
        for (int i = 0; i < actions.Length; i++)
        {
            action(((i + 1) * 100) / actions.Length)
        }
    }
