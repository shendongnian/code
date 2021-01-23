    using System;
    using System.IO;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    using System.Security.Cryptography;
    
    public partial class UserDefinedFunctions
    {
        [Microsoft.SqlServer.Server.SqlFunction(DataAccess = DataAccessKind.None, IsDeterministic = true, SystemDataAccess = SystemDataAccessKind.None)]
        public static SqlBinary Hash(SqlBytes source, SqlString hashAlgorithmName)
        {
            if (Source.IsNull) 
            {
                return null;
            }
    
            using (HashAlgorithm ha = GetHashAlgotithm(hashAlgorithmName.Value)) 
            using (Stream stream = Source.Stream) 
            {
                return new SqlBinary(ha.ComputeHash(source.Stream));
            }
        }
    }
