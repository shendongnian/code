    void dt_ColumnChanging(object sender, DataColumnChangeEventArgs e)
    {
         if (e.Column == dt.Columns["myColumn"])
         {
             if (e.ProposedValue == null)
             {
                  e.ProposedValue = DBNull.Value;
             }
         }
    }
