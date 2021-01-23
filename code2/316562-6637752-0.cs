    if (list.Count <= 10)
    {
        lvUndoStack.Items.AddRange(list.ToArray());
    }
    else
    {
        for (int i = 0; i < 10; i++)
        {
            lvUndoStack.Items.Add(list[0]);
        }
    }
