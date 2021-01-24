    using SqlKata;
    using SqlKata.Compilers;
    
    // Create an instance of SQLServer
    var compiler = new SqlServerCompiler();
    
    var query = new Query("Users").Where("Id", 1).Where("Status", "Active");
    
    SqlResult result = compiler.Compile(query);
    
    string sql = result.Sql;
    List<object> bindings = result.Bindings; // [ 1, "Active" ]
