    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
    {
        DataRowView dRV = (DataRowView)bindingSource1.Current;
        DateTime myDate = (DateTime)dRV["MyDate"];
        string myName = (string)dRV["MyName"];
        if (DeleteRow(myDate, myName))
        {
            GetData4();
        }
    }
