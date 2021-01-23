    public string Valid(OleDbDataReader myreader, int stval)
        {
            object val = myreader[stval];
            if (val != DBNull.Value)
            {
                return val.ToString() ;
            }
            else
            {
               return Convert.ToString(0); //forgot to write return over her
            }
        }
