    clasCon Crud = new clasCon();
    var procName = "MyProcedure";
    var parameters = new List<OleDbParameter>();
    parameters.Add(new OleDbParameter("@FName", txtFname.Text.Trim()));
    parameters.Add(new OleDbParameter("@MName", txtMname.Text.Trim()));
    parameters.Add(new OleDbParameter("@LName", txtLname.Text.Trim()));
    Crud.ExecuteProcedure(procName, parameters);
