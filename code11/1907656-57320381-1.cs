    clasCon Crud = new clasCon();
    var procName = "MyProcedure";
    var parameters = new List<OleDbParameter>();
    parameters.Add("@FName", txtFname.Text.Trim());
    parameters.Add("@MName", txtMname.Text.Trim());
    parameters.Add("@LName", txtLname.Text.Trim());
    Crud.ExecuteProcedure(procName, parameters);
