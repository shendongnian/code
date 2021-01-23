    string oldMsg = "";
    public void ShowStatus(string status)
    {
        oldMsg = this.StatusMessage.Text;
        this.StatusMessage.Text = status;
        this.StatusMessage.Invalidate(); // To force status bar redraw
        this.StatusMessage.Refresh();
    }
    
    public void RestoreStatus()
    {
        this.StatusMessage.Text = oldMsg;
    }
