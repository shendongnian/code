    public void ExecuteProcedure(string procName, List<OleDbParameter> parameters)
    {
        try
        {
            vbcon(); // connection
            cmd = new OleDbCommand(procName, ConnS);
            cmd.CommandType = CommandType. StoredProcedure;
            foreach(var parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script>alert('Query error! 
             :" + ex.Message + "'</script>");
        }
        finally
        {
            GC.Collect();
        }
    }
