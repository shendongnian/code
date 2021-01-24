    public static List<Reservering> GetReserverings()
        {
            List<Reserving> reservings = new List<Reservings>();
        
            using (var conn = new SqlConnection(ConnectionString))
            {
                    conn.Open();
                    const string query = "select b.boekingid, k.naam, bk.incheckdatum, bk.uitcheckdatum, b.hotelid, b.aantal_gasten from boeking b join klant k on k.klantid = b.boekingid join boekingkamer bk on b.boekingid = bk.boekingid where bk.incheckdatum is not null and bk.uitcheckdatum is not null";
        
                    SqlCommand selectReserveringen = new SqlCommand(query, conn);
        
                    SqlDataReader reader = selectReserveringen.ExecuteReader();
        
                    while (reader.Read())
                    {
        
                         Reservering res = new Reservering();
                         res.Id =  (int)reader["boekingid"];
                         res.Naam = (string)reader["naam"];
                         res.Incheck_datum = (DateTime)reader["incheckdatum"];
                         res.Uitcheck_datum = (DateTime)reader["uitcheckdatum"];
                         res.Hotel = (int)reader["hotelid"];
                         res.Aantal_personen = (int)reader["aantal_gasten"];
                         reservings.add(res);
                    }
        
                    reader.Close();
                }
        
                return reservings;
        }
