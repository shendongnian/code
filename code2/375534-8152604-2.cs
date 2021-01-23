    public void Run(params Action<int>[] actions)
    {      
        for (int i = 0; i < actions.Length; i++)
        {
            Action<int> action = actions[i];
            int progress = ((i + 1) * 100) / actions.Length;
            action(progress);
        }
    }
