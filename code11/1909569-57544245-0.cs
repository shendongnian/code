    private void ProcessRemovals(ArrayList removals)
    {
        foreach (dynamic item in removals)
        {
            var deleteItem = item.RemovalCondition.Invoke(item.Data);
            if (deleteItem)
            {
               //do something here
            }
        }
    }
