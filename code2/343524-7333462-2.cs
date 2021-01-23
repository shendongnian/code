    private void Story_Completed(object sender, EventArgs e)
    {
        if (one.Opacity == 0)
        {
            Container_one.Children.Remove(one);
        }
    }
