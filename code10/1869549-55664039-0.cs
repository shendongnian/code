    protected void btnShowOrder_Click(object sender, EventArgs e)
    {
        //cast the sender back to a button
        Button btn = sender as Button;
        //get the current item from the listview namingcontainer
        ListViewItem item = btn.NamingContainer as ListViewItem;
        //use findcontrol to locate the label in that item
        Label lbl = item.FindControl("lblprodId") as Label;
        //show result in label outside listview
        Label1.Text = lbl.Text;
    }
