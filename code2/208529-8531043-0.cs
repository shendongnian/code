        String matchString="ID0001"//assuming we have to find rows having key=ID0001
        DataTable dtTarget = new DataTable();
        dtTarget = dtSource.Clone();
        DataRow[] rowsToCopy;
        rowsToCopy = dtSource.Select("key='" + matchString + "'");
        foreach (DataRow temp in rowsToCopy)
        {
            dtTarget.ImportRow(temp);
        }
