    foreach (DataListItem i in DataList1.Items) // Iterates through each of your Items
    {
        foreach (Control c in i.Controls) // Iterates through all the Controls in each Item
        {
            try // Try to cast the Control as a Label (to see if it is one)
            {
                Label temp = (Label)c;
                temp.Text = "junk";
            }
            catch (InvalidCastException castError)
            {
                // Don't do anything, it wasn't a label.
            }
        }
    }
