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
        [Microsoft.SqlServer.Server.SqlFunction(IsDeterministic=true,
                                                DataAccess=DataAccessKind.None)]
        public static SqlBytes fn_compress(SqlBytes blob)
        {
            if (blob.IsNull)
                return blob;
    
            // Retrieving BLOB data
    
            byte[] blobData = blob.Buffer;
    
            // Preparing for compression
            MemoryStream compressedData = new MemoryStream();
            DeflateStream compressor = new DeflateStream(compressedData,
                                               CompressionMode.Compress, true);
    
            // Writting uncompressed data using a DeflateStream compressor
            compressor.Write(blobData, 0, blobData.Length);
    
            // Clossing compressor to allow ALL compressed bytes to be written
            compressor.Flush();
            compressor.Close();
            compressor = null;
    
            // Returning compressed blob
            return new SqlBytes(compressedData);
        }
    };
