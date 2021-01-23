    public CustomTaskPane TaskPane
    {
        get{return taskPaneValue;}
    }
    
    private TaskPaneControl taskPaneControl1;
    private CustomTaskPane taskPaneValue;
    private WpfControl con;
    
    internal void AddTaskPane()
    {
        ElementHost host = new ElementHost();
        con = new WpfControl();
        host.Child = con;
        host.Dock = DockStyle.Fill;
        taskPaneControl1 = new TaskPaneControl();
        taskPaneControl1.Controls.Add(host);
        taskPaneValue = this.CustomTaskPanes.Add(taskPaneControl1, "My Taskpane");
        taskPaneValue.Visible = true;
    }
