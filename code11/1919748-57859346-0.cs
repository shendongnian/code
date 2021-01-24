    var userNameParam = new SqlParameter("username", SqlDbType.VarChar);
    userNameParam.Value = Session["username"].ToString();
    var idParam = new SqlParameter("id", SqlDbType.Int);
    idParam .Value = id;
    command.Parameters.Add(salaryParam);
    command.Parameters.Add(idParam );
