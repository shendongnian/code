    private void taskPaneValue_VisibleChanged(object sender, System.EventArgs e)
    {
        Globals.Ribbons.ManageTaskPaneRibbon.toggleButton1.Checked = 
            taskPaneValue.Visible;
    }
