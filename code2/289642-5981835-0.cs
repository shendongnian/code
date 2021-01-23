    public static string GetFormatedDecimalString(DataRow row, string columnName, string format)
    {
    
        string ColumnNameStringValue = String.Empty;
        decimal ColumnNameValue = Decimal.Zero;
    
        if( row["ColumnName") == DBNull.Value )
        {
            ColumnNameValue = Decimal.Zero;
        }
        else
        {
            ColumnNameStringValue = row["ColumnName"].ToString();
    
            if( ! Decimal.TryParse(ColumnNameStringValue, out ColumnNameValue )
            {
               ColumnNameValue = Decimal.Zero;
            }
    
            // if the if statement evaluated to false the ColumnNameValue will have the right
            // number you are looking for.
        }
    
        return ColumnNameValue.ToString(format);
    }
