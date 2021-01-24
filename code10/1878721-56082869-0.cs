        using (var con = new SqlConnection("server=.;database=tempdb;Integrated Security=true"))
        {
            con.Open();
            var cmd = new SqlCommand("select cast(4210862852.86 as decimal(38,20))  val", con);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                var val = rdr.GetDecimal(0);
                Console.WriteLine(val);
            }
        }
