    public static List<Reservering> GetReserverings() {
      List<Reservering> result = new List<Reservering>();
    
      using (var conn = new SqlConnection(ConnectionString)) {
        conn.Open();
    
        const string query = 
          @"select b.boekingid, 
                   k.naam, 
                   bk.incheckdatum, 
                   bk.uitcheckdatum, 
                   b.hotelid, 
                   b.aantal_gasten 
              from boeking b join 
                   klant k on k.klantid = b.boekingid join 
                   boekingkamer bk on b.boekingid = bk.boekingid 
             where bk.incheckdatum is not null 
               and bk.uitcheckdatum is not null";
    
         using (SqlCommand selectReserveringen = new SqlCommand(query, conn)) {
           using (SqlDataReader reader = selectReserveringen.ExecuteReader()) {
             while (reader.Read()) {
               Reservering res = new Reservering();
               result.Add(res); 
     
               res.Id              = Convert.ToInt32(reader["boekingid"]);
               res.Naam            = Convert.ToString(reader["naam"]);
               res.Incheck_datum   = Convert.ToDateTime(reader["incheckdatum"]);
               res.Uitcheck_datum  = Convert.ToDateTime(reader["uitcheckdatum"]);
               res.Hotel           = Convert.ToInt32(reader["hotelid"]);
               res.Aantal_personen = Convert.ToInt32(reader["aantal_gasten"]);  
             }
           } 
         }
       }      
       return result;
    }
