    if (item.GetType() == typeof(Microsoft.SqlServer.Types.SqlGeography)) 
    {
         SqlParameter p = new SqlParameter();
         p.SqlDbType = System.Data.SqlDbType.Udt;
         p.UdtTypeName = "geography";
         p.Value = value;
    }
     
 
            
            
