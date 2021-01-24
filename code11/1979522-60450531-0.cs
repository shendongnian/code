    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G9SO8KA;Initial Catalog=coolege;Integrated Security=True");
    string qry="select * from tblstudent where Email='@name and Password=@pass";
    adpt = new SqlDataAdapter(qry,con);
    adpt.SelectCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = Login1.UserName;
    adpt.SelectCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = Login1.Password;
    con.Open();
    ...
       
