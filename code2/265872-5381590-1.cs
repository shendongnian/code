    protected void mybutton_click()
    {
        StringBuilder sb = new StringBuilder();
        foreach(ListItem item in CustomerListBox.Items)
        {
             
             If(item.selected)
             {
                 sb.Append(item.SelectedValue+",");
             }
        }
    
        FillGridview(sb);
    }
    
    private void FillGridview(StringBuilder sb)
    {
        string s = sb.tostring().remove().lastindexof(",");
        //pass this string as param and set it your where condition.
        // Get the datatble or collection and bind grid.
    }
    Select your desired columsn to display 
    From Your Tables (put joins if required)
    Where CustomerNumber IN (@CommaSeparatedAboveString_s);
