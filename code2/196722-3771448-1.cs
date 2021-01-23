    private IE ie = new IE();
    public void btnStartBrowsing_Click(object sender, EventArgs e)
    {
        using ie2 = ie.AttachTo<IE>(Find.ByUrl(URLs.mainURL))
        {
            ...
        }
    }
