    // create an SQL Parameter object
    SqlParameter p = new SqlParameter("dummy", myObj);
    
    // ask SQL code to compute its SqlDbType for us
    Console.WriteLine(p.SqlDbType);
