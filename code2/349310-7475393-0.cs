    OracleConnection conn = new OracleConnction(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
    try{
        conn.Open();
    catch(Exception){
        System.Console.Out.WriteLine("Please modify db connection data in app.config.")
    }
