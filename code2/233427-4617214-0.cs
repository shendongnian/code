    public void Register(Action operation)
        {
            operations.Add(operation);
        }
    public void Execute()
        {
            foreach (var action in operations)
              Task.StartNew(operation);
        }
