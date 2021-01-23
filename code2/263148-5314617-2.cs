    using (SqlConnection conn = new SqlConnection("connectionString"))
            {
                conn.Open();
    
                using (SqlTransaction trans = conn.BeginTransaction())
                using (SqlCommand comm1 = new SqlCommand("INSERT INTO Foos(fooName) VALUES('Bar1')", conn, trans))
                using (SqlCommand comm2 = new SqlCommand("INSERT INTO Foos(fooName) VALUES('Bar2')", conn, trans))
                {
                    comm1.ExecuteNonQuery();
                    trans.Save("MySavePoint");
                    comm2.ExecuteNonQuery();
                    trans.Rollback("MySavePoint");
                    trans.Commit();
                }
            }
