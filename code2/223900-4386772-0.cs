    private string GetList(ds)
    {
        var result = string.Empty;
        for(int i = 0; i < ds.Rows.Count; i++)
        {
             result += ds.Row[i][0] + ",";
        }
        result = result.Trim(',');
        return result;
    }
