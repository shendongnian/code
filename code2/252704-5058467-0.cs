    <asp:ListView onitemdatabound="myListView_ItemDataBound" runat="server" ID="myListView" ...
    protected void myListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            int commentId = (int)DataBinder.Eval(dataItem, "CommentId");
            // get author id based on comment id
            // or if you have auther id within the datasource
            // by which you are binding the listview then
            int ID_Author = (int)DataBinder.Eval(dataItem, "ID_Author");
            
            // get a reference to the delete button in the item
            // for instance you may do by this
            Control delete_button = e.Item.FindControl("deleteButtonId");
            // will hide if the author id don't match with the session id
            delete_button.Visible = ID_Author.Equals((int)Session["loggedin_userId"]);
        }
    }
