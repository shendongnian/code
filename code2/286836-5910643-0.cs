    DataTable GetTopN(int n, DataTable content)
    {
        DataTable dtNew = content.Clone();
        if (n > content.Rows.Count)
            n = content.Rows.Count;
    
        for(int i=0; i<n; i++)
        {
            dtNew.ImportRow(content.Rows[i]);
        }
    }
