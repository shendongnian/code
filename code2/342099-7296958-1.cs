    foreach (DataListItem i in DataList1.Items) // Iterates through each of your Items
    {
        foreach (Control c in i.Controls) // Iterates through all the Controls in each Item
        {
            if (c is Label) // Make sure the control is a Label control
            {
                Label temp = (Label)c;
                temp.Text = "junk";
            }
        }
    }
