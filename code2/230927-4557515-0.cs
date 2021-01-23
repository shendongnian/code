    private delegate void UpdateTextDelegate(object value);
    
    private void UpdateText(object value)
    {
        if (this.textbox.InvokeRequired)
        {
            // This is a worker thread so delegate the task.
            this.textbox.Invoke(new UpdateTextDelegate(this.UpdateText), value);
        }
        else
        {
            // This is the UI thread so perform the task.
            this.textbox.Text = value.ToString();
        }
    }
