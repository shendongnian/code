    void anyButton_Click(object sender, EventArgs e)
    {
        var button = (sender as Button);
        if (button != null)
        {
            button.Visible = false;
        }
    }
