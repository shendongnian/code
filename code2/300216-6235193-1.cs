        //New list that will contain the Objects to be deleted later on.
        List<DataGridView> listToDelete = new List<DataGridView>();
        
        if (a.Count != 0)
        {
            foreach(DataGridViewRow row in a )
            {
                foreach (DataGridViewRow newrow in b)
                {
                    if( row.Cells[0].Value.ToString() == newrow.Cells[0].Value.ToString() &&
                    row.Cells[1].Value.ToString() == newrow.Cells[1].Value.ToString())
                    {
                        listToDelete.Add(row);
                    }
                }
            }
        }
   
        foreach (DataGridView d in listToDelete) {
            a.Remove(d);
        }
    
