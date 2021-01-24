    public void plus(int n)
    {
    	((Label)this.Controls.Find("label" + (n + 1), false)[0]).Visible = true;
    	((ComboBox)this.Controls.Find("combobox" + (n + 1), false)[0]).Visible = true;
    	((Button)this.Controls.Find("plusButton" + (n + 1), false)[0]).Visible = true;
    	((Button)this.Controls.Find("minusButton" + (n + 1), false)[0]).Visible = true;
    }
