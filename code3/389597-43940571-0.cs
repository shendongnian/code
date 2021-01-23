    try
    {
        BindingSource1.RemoveCurrent();
        BindingSource1.EndEdit();
        Table1TableAdapter.Update(dataSet01.Table1);
        dataSet01.Table1.AcceptChanges(); <====== add this
    }
    catch (Exception ex)
    {
    MessageBox.show(ex.Message);
    } 
