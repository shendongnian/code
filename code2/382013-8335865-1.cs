    using System.Data.SqlTypes;
    ...
    
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static void BackupStuff(string dataID, out SqlBinary backup)
        {
           [..body omitted..]
           byte[] result = ... // get byte array to return
           backup = new SqlBinary(result);
        }
