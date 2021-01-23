    public class CustomOracleDriver : OracleClientDriver
    {
        protected override void InitializeParameter(System.Data.IDbDataParameter dbParam, string name, SqlType sqlType)
        {
            base.InitializeParameter(dbParam, name, sqlType);
            
            // System.Data.OracleClient.dll driver generates an ORA-01461 exception because 
            // the driver mistakenly infers the column type of the string being saved, and 
            // tries forcing the server to update a LONG value into a CLOB/NCLOB column type. 
            // The reason for the incorrect behavior is even more obscure and only happens 
            // when all the following conditions are met.
            //   1.) IDbDataParameter.Value = (string whose length: 4000 > length > 2000 )
            //   2.) IDbDataParameter.DbType = DbType.String
            //   3.) DB Column is of type NCLOB/CLOB
            // The above is the default behavior for NHibernate.OracleClientDriver
            // So we use the built-in StringClobSqlType to tell the driver to use the NClob Oracle type
            // This will work for both NCLOB/CLOBs without issues.
            // Mapping file must be updated to use StringClob as the property type
            // See: http://thebasilet.blogspot.be/2009/07/nhibernate-oracle-clobs.html
            if ((sqlType is StringClobSqlType))
            {
                ((OracleParameter)dbParam).OracleType = OracleType.NClob;
            }
        }
    }
