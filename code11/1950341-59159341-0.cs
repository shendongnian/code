    for(int i = eventDBDataSet.Contacts.Rows.Count-1; i >= 0; i--)
    {
        DataRow dr = eventDBDataSet.Contacts.Rows[i];
        if (dr["name"] == "contactsRow")
            dr.Delete();
    }
    eventDBDataSet.Contacts.AcceptChanges();
