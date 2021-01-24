    private void ProcessRemovals(ArrayList removals)
    {
        foreach (IProcessRemoval item in removals)
        {
            var deleteItem = item.Execute();
            if (deleteItem)
            {
               //do something here
            }
        }
    }
