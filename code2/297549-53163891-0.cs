    string strConexao = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;
    conexaoBD = new SqlConnection(strConexao);
    conexaoBD.Open();
    var result = conexaoBD.Query("Select Field1,Field2 from Table").First();
    //access field value result.Field1 
    //access field value result.Field2
           
    if (result.Field1 == "abc"){ dosomething}
