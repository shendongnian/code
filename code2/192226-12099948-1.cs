    protected void Repeater1_PreRender(object sender, EventArgs e)
    {
        if (Repeater1.Items.Count < 1)
        {
            NoRecords.Visible = true;
            Repeater1.Visible = false;
        }
    }
