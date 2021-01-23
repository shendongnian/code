    protected void prevSubList_DataBound(object sender, EventArgs e)
    {
         foreach (ListItem item in prevSubList.Items)
         {
             if (item.Text.Contains("AA"))
                item.Attributes.Add("style","background-color:green;");
             else if(item.Text.Contains("BB"))
                item.Attributes.Add("style", "background-color:blue;");
         }
    }
