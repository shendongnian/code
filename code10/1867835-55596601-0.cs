    private void Button1_Click(object sender, EventArgs e)
    {
        if (!questionList.Items.Cast<string>().Contains(customQ.Text.Trim()))
        {
            dbconnect.addQ(customQ.Text);
            refreshBox();
        }
    }
