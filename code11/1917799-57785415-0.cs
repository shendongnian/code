            ...
            conn.Open();
            // Oracle uses : not @ for parameters
            string query = 
              @"INSERT INTO TMCI_PPC_IMPORTDATA_PSI (
                  ITEM, 
                  REQUIREMENT, 
                  REQ_DATE)
                VALUES (
                  :Itm, 
                  :Req, 
                  :ReqDT)";
            //DONE: wrap IDisposable into using
            using (OracleCommand cmd = new OracleCommand(query, conn)) {
              //DONE: create parameters once
              //TODO: validate parameters' types
              cmd.Parameters.Add(":Itm", OracleDbType.Varchar2);
              cmd.Parameters.Add(":Req", OracleDbType.Varchar2);
              cmd.Parameters.Add(":ReqDT", OracleDbType.Date);
              foreach(DataRow importRow in importData.Rows) { 
                // assign parameters as many as you want
                cmd.Parameters[":Itm"].Value = importRow["ITEM"];
                cmd.Parameters[":Req"].Value = importRow["REQUIREMENT"];
                cmd.Parameters[":ReqDT"].Value = importRow["REQUIREMENT"];
                cmd.ExecuteNonQuery(); 
              }  
            }
