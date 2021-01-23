    //double check and make sure that this is getting the correct item
    ListViewItem commentItem = ((LinkButton)sender).NamingContainer as ListViewItem;
    if (commentItem != null)
    {
        //instead of using the DisplayIndex use the DataItemIndex
        int id = (int)lvComments.DataKeys[commentItem.DataItemIndex]["Id"];
    }
