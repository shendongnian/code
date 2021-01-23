    DataSet dsActive = new DataSet();
    dsActive.ReadXml(UsersXmlReader);
    
    DataSet dsInactive = ds.Copy();//Copy to your another dataset
    Remove(dsActive.Tables[0], "0");//Remove all inactive(where Active = 0) records from dsActive DataSet
    Remove(dsInactive.Tables[0], "1");//Remove all active(where Active = 1) records from dsInactive DataSet
    
    private void Remove(DataTable table, string active)
    {
        for (int i = 0; i < table.Rows.Count; i++)
        {
            if (table.Rows[i]["Active"].Equals(active))
            {
                table.Rows[i].Delete();
                i = i - 1;//Removed record so we need to check same index
            }
        }
    }
