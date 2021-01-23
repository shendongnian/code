    using System;
    using System.Collections.Generic;
    using System.Data;
    using LiabilitiesMI.Common.DataObjects;
    using Sybase.Data.AseClient;
     
    namespace LiabilitiesMI.Common.Interfaces
    {
        public interface ISybaseDBHelper : IDisposable
        {
            DataSet GetDataUsingStoredProcedure(string storedProcedureName, DatabaseEnum dbName, List<AseParameter> parameters);
            int InsertDataUsingStoredProcedure(string storedProcedureName, DatabaseEnum dbName, List<AseParameter> parameters);
        }
    }
 
 
