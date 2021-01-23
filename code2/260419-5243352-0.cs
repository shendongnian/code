    public void SetText(string text) 
    {
        if (this.InvokeRequired) 
        {
            this.Invoke(new Action<string>(SetText), text);
        }
        else 
        { 
            this.Text = text;
        }
    }
