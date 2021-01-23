    public void Remove(ListControl todoList, ListControl doneList)
    {
        for (int i = 0; i <= (todoList.SelectedItems.Count - 1); i++)
        {
            doneList.Items.Add(todoList.SelectedItems[i]);
            todoList.Items.Remove(todoList.SelectedItems[i]);
        }
    }
