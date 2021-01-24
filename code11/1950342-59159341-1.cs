    foreach (DataRow row in EventDBDataSet.ContactsRow.Select())
    	{
    		if (row["ID"].ToString().Equals("ROW TO DELETE"))
    		{
    			EventDBDataSet.ContactsRow.Rows.Remove(row);
    		}
    	}
    
    	EventDBDataSet.ContactsRow.AcceptChanges();
