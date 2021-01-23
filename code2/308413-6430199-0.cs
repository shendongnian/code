    public string deletest {get;set;}
    private void deletetask_Click(object sender, EventArgs e)
    {
        deletest = DeleteTaskBox.Text;
        ScheduledTasks st = new ScheduledTasks(@"\\" + System.Environment.MachineName);
        st.DeleteTask(deletest);
    }
