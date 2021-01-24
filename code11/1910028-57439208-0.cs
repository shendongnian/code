    // employeeIds is a list of IDs; could be any value
    int parmNumber = 0;
    List<string> parms = new List<string>();
    foreach (string id in employeeIds) {
      string parmName = $":id{parmNumber++}"; // id0 or id1 or etc.
      parms.Add(parmName);
      // "command" is the OracleCommand/DbCommand/whatever instance
      command.Parameters.Add(new OracleParameter(parmName, id)); 
    }
    string ids = string.Join(",", parms); // ":id0, :id1, etc."
    string query = $"Select Name, Id from Employee where Id IN ({ids})";
