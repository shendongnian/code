    public DataTable CopyDataTable(DataTable dtSource, int iRowsNeeded)
    {
    
        if (dtSource.Rows.Count > iRowsNeeded)
        {
            // cloned to get the structure of source
            DataTable dtDestination = dtSource.Clone();
            for (int i = 0; i < iRowsNeeded; i++)
            {
                dtDestination.ImportRow(dtSource.Rows[i]);
            }
            return dtDestination;
        }
        else
            return dtSource;
    }
