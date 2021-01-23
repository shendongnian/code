     public DataTable Get_All_Inse(string NomTable)
        {
            try
            {
                using (var connectionWrapper = new Connexion())
                {
                    var connectedConnection = connectionWrapper.GetConnected();
                    string sql_SelectAll = "SELECT * FROM " + NomTable;
                    SqlCommand comm_SelectAll = new SqlCommand(sql_SelectAll, connectionWrapper.conn);
                    SqlDataAdapter adapt_SelectAll = new SqlDataAdapter();
                    adapt_SelectAll.SelectCommand = comm_SelectAll;
                    DataTable dSet_SelectAll = new DataTable();
                    adapt_SelectAll.Fill(dSet_SelectAll);
                    dSet_SelectAll.Dispose();
                    adapt_SelectAll.Dispose();
                    return dSet_SelectAll;
                }
            }
            catch (Exception excThrown)
            {
                if (!excThrown.Message.StartsWith("Err_")) { throw new Exception("Err_GetAllUsrClient", excThrown); }
                else { throw new Exception(excThrown.Message, excThrown); }
            }
        }
