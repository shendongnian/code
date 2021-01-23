    public void UpdateSub(string message)
    {
        if (!subDisplay.subBox.InvokeRequired)
        {
            subDisplay.subBox.Text = message;
        }
        else
        {
            var d = new UpdateFormText(UpdateSub);
            Invoke(d, new object[] { message });
        }
    }
