    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList arrSample = new ArrayList();
    
        // populate ArrayList
        arrSample.Items.Add(0, "a");
        arrSample.Items.Add(1, "b");
        arrSample.Items.Add(2, "c");
    
        // walk through the length of the ArrayList
        for (int i = 0; i < arrSample.Items.Count; i++)
        {
            // you could, of course, use any string variable to search for.
            if (arrSample.Items[i] == "a")
                lbl.Text = arrSample.Items[i].ToString();
        }
    }
