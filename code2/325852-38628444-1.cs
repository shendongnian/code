                using (myCmd)
                {
                    myCmd.Parameters.AddWithValue("p_session_id", sessionId);
                    myCmd.Parameters.AddWithValue("p_user", SessionHelper.UserEmailID);
                    OracleParameter retval = new OracleParameter("p_status", OracleType.NVarChar, 35);
                    retval.Direction = ParameterDirection.Output;
                    myCmd.Parameters.Add(retval);
                    OracleParameter retval2 = new OracleParameter("p_status_dtl", OracleType.NVarChar, 300);
                    retval2.Direction = ParameterDirection.Output;
                    myCmd.Parameters.Add(retval2);
                    OracleParameter retval3 = new OracleParameter("p_output", OracleType.Cursor);
                    retval3.Direction = ParameterDirection.Output;
                    myCmd.Parameters.Add(retval3);
                    myCmd.ExecuteNonQuery();
                    status = myCmd.Parameters["p_status"].Value.ToString();
                    statusDetail = myCmd.Parameters["p_status_dtl"].Value.ToString();
                    using (OracleDataReader reader = (OracleDataReader)myCmd.Parameters["p_output"].Value)
                    {
                        outPutDt.Load(reader);
                    }
                }
}
