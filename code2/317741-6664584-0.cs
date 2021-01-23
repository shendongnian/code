    for(int i = this.Controls.Count - 1; i >= 0; i--)
    {
        if (this.Controls[i] is Label && this.Controls[i].ID != "error")
        {
            this.Controls.Remove(this.Controls[i]);
        }
    }
