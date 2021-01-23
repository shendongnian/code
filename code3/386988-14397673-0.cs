    myListView.Columns.Add("Nr"); //column 1 heading
    myListView.Columns.Add("Desc"); //column 2 heading
    myListView.View = View.Details; //make column headings visible
    foreach (var item in someDataList) //item has strings for each column of one row
    {
        // create new ListViewItem
        ListViewItem lvi = new ListViewItem(item.Text1);
        lvi.SubItems.Add(item.Text2);
        // add the listviewitem to a new row of the ListView control
        myListView.Items.Add(lvi); //show Text1 in column1, Text2 in col2
    }
