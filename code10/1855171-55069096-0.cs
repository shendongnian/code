    private void ReturningValues()
    {
        string list = "25 28 32 41";
        string[] values = list.Split(' ');
        //loop the values in the array
        foreach (var checkbox in values)
        {
            p1.Items.Add(new ListItem() { Text = checkbox, Value = checkbox });
        }
        //add items to p1
        p1.DataBind();
    }
