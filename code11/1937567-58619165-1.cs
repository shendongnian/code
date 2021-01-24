    private void TaskBox_MouseUp(object sender, MouseEventArgs e)
    {
        foreach (int index in taskBox.CheckedIndices)
        {
            fTaskBox.Items.Add(taskBox.Items[index]);
            taskBox.Items.RemoveAt(index);
        }
    }
