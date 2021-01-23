     protected void MyListView_ItemDataBound(object sender, ListViewItemEventArgs e)
     {
         LinkButton linkButton = (LinkButton)e.Item.FindControl("linkButtonId");
         System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
    
         //.. can hide and show depending on data
         linkButton.Visible = rowView["SomeData"].ToString() == "SomeValue";
         
         //.. or set command arg
         linkButton.CommandArgument = rowView["SomeMoreData"].ToString();
    }
