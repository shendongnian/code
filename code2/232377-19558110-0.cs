    protected void SqlDataSource1_Updating(object sender, SqlDataSourceCommandEventArgs e) {
        foreach (DbParameter parameter in e.Command.Parameters) {
            parameter.Value = Server.HtmlEncode(parameter.Value);
        }
    }
