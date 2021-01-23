    public string DeleteTaskName { get; set; }
    private void deletetask_Click(object sender, EventArgs e)
    {
        // Note that this doesn't declare a variable
        DeleteTaskName = DeleteTaskBox.Text;
        ScheduledTasks st = new ScheduledTasks(@"\\" + Environment.MachineName);
        st.DeleteTask(DeleteTaskName);
    }
