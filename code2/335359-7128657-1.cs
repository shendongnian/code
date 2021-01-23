    protected void ImageButton1_Command(object sender, EventArgs e)
    {
        string targetPage = "..."
        ((ImageButton)sender).Attributes.Add("onclick", targetPage);
    }
