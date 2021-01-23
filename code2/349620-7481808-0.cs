    string query = "INSERT INTO Indkøbsliste (ListID, ListeNr, Stregkode, Navn, Antal, Pris)   
             Values (@ListID, @ListeNr, @Stregkode, @Navn, @Antal, @Pris)"
    
    SqlCommand com = new SqlCommand(query, myCon);
    com.Parameters.Add("@ListID",System.Data.SqlDbType.Int).Value=id;
    com.Parameters.Add("@ListeNr",System.Data.SqlDbType.Int).Value=listnr;
    com.Parameters.Add("@Stregkode",System.Data.SqlDbType.VarChar).Value=strege ;
    com.Parameters.Add("@Navn",System.Data.SqlDbType.VarChar).Value=navn ;
    com.Parameters.Add("@Antal",System.Data.SqlDbType.Int).Value=il.Antal;
    com.Parameters.Add("@Pris",System.Data.SqlDbType.Int).Value=il.Pris;
            
    com.ExecuteNonQuery();
