    void IncreaseBtn_Click(Object sender, EventArgs e)
    {
        var value = this.myLabel.Text;
        var intValue = 0;
        Int32.TryParse(value, out intValue);
        this.myLabel.Text = (++intValue).ToString();
    }
    void DecreaseBtn_Click(Object sender, EventArgs e)
    {
        var value = this.myLabel.Text;
        var intValue = 0;
        Int32.TryParse(value, out intValue);
        this.myLabel.Text = (--intValue).ToString();
    }
