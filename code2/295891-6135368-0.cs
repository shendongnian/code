    // Add the parameters for the UpdateCommand.
    command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
    command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");
    SqlParameter parameter = command.Parameters.Add(
        "@oldCustomerID", SqlDbType.NChar, 5, "CustomerID");
    parameter.SourceVersion = DataRowVersion.Original;
    adapter.UpdateCommand = command;
