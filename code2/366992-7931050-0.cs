     public static DateTime? GetDate( this DataRow Row, string ColumnName )
        {
    
            object Value = Row[ ColumnName ];
    
            if( Value == DBNull.Value )
                return null;
            else
                return (DateTime)Value;
    
        }
    // Repeat for other types, or use a generic version.
    ...
    DateTime? dtlogout = row.GetDate("visit_Logout_DateTime");
