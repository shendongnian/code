    protected DataTable getTable()
    {
    DataTable dt = new DataTable();
    StringBuilder cmdText = new StringBuilder();
    cmdText.Append("SELECT AgentLogin.Username, AgentDetail.FirstName,    AgentDetail.LastName");
            cmdText.Append("FROM Orders INNER JOIN");
            cmdText.Append("AgentLogin ON AgentDetail.AgentNumID = AgentLogin.AgentNumID ");
    
    return dt;
    }
            
