    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    
    using System.IO;
    using System.IO.Compression;
    
    public partial class UserDefinedFunctions
    {
        // Setting function characteristics
        [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic=true, DataAccess=DataAccessKind.None)]
        public static void fn_WriteToFile(string fileName, SqlBytes blob)
        {
            if( blob.IsNull || String.IsNullOrEmpty(fileName) )
            {
                return;
            }
			
            String fullFileName = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), fileName);
            using( FileStream fileStream = new  FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.Write))
            using( BinaryWriter binaryWriter = new BinaryWriter(fileStream) )
            {
                binaryWriter.Write(blob.Buffer);
            }
        }
    };
