        public int ExecuteNonQuery(string cmdText, CommandType cmdType, List<IParam> parms)
        {
            SqlCommand cmd = CreateCommand(cmdText, cmdType, parms);
            using (cmd.Connection)
            {
                cmd.Connection.Open();
                int ret = cmd.ExecuteNonQuery();
                UnloadParms(parms, cmd);
                return ret;
            }
        }
And add the following method.
private static void UnloadParms(List<IParam> parms, SqlCommand cmd)
        {
            if (parms != null)
            {
                for (int i = 0; i <= parms.Count - 1; i++)
                {
                    IParam p = parms[i];
                    p.Value = cmd.Parameters[i].Value;
                    parms[i] = p;
                }
            }
        }
