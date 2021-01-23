    public void InvertSelection(ListBox objLstbox)
    {
        if (objLstbox == null) return;
        for (int i = 0; i < objLstbox.Items.Count; i++)
            objLstbox.Items[i].Selected = !objLstbox.Items[i].Selected; 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        InvertSelection(ListBox1);
    }
