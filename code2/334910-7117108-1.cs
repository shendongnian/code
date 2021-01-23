    for (int i = 0; i < multiTaskChecks.Items.Count; i++)
    {
        if (multiTaskChecks.GetItemChecked(i))
        {
            checkedMultiTasks.Add(multiTaskChecks.GetItemText(multiTaskChecks.Items[i]));
        }
    }
