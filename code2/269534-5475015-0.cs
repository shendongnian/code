    CREATE PROCEDURE Outs 
    	@var1 INT OUTPUT,
    	@var2 INT OUTPUT
    AS
    BEGIN
    	SELECT	@var1 = 1,
    			@var2 = 2
    END
    GO
            var connectionstring = @"server=rickshaw;database=becak;Trusted_Connection=true;";
            using(var conn = new SqlConnection(connectionstring))
            using(var cmd = new SqlCommand("Outs", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.Add("@var1", SqlDbType.BigInt);
                    cmd.Parameters.Add("@var2", 0);
                    cmd.Parameters["@var1"].Value = DBNull.Value;
                    cmd.Parameters["@var1"].Direction = ParameterDirection.InputOutput;
                    cmd.Parameters["@var2"].Value = 0;
                    cmd.Parameters["@var2"].Direction = ParameterDirection.Output;
                    cmd.ExecuteScalar();
                    conn.Close();
                    var var1 = cmd.Parameters["@var1"].Value;
                    var var2 = cmd.Parameters["@var2"].Value;
                    Console.WriteLine("var1=" + var1);
                    Console.WriteLine("var2=" + var2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();
