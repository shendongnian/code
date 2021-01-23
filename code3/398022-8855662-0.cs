    try
    {
       aBindingSource.EndEdit();
       dbDataSetA.GetChanges();
       aTableAdapter.Update(dbDataSetA.Accounts);   
    }
    catch (DBConcurrencyException exc)
    {
       MessageBox.Show("original data changed, please redo updates");
       aTableAdapter.Fill(dbDataSetA);
    }
