    public string Valid(OleDbDataReader myreader, int stval)
    {
        object val = myreader[stval];
        if (val != DBNull.Value)
        {
            return val.ToString() ;
        }
        else
        {
            Convert.ToString(0);
        }
    }
