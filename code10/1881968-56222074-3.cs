    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Taskovi> UzmiTaskove(int idprojekta)
    {
            List<Taskovi> listataskova = new List<Taskovi>();
            string CS = Properties.Settings.Default.Konekcija.ToString();
    
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd4 = new SqlCommand("UzmiTaskove", con);
                cmd4.CommandType = CommandType.StoredProcedure;
    
                con.Open();
    
                cmd4.Parameters.AddWithValue("@IdProj", idprojekta);
    
                SqlDataReader rdr = cmd4.ExecuteReader();
    
                while (rdr.Read())
                {
                    Taskovi tas = new Taskovi();
                    tas.ID = Convert.ToInt32(rdr["ID"]);
                    tas.IdProjekta = Convert.ToInt32(rdr["IdProjekta"]);
                    tas.Opis = rdr["Opis"].ToString();
                    tas.DatumPocetka = rdr["DatumPocetka"].ToString();
                    tas.DatumZavrsetka = rdr["DatumZavrsetka"].ToString();
                    tas.Status = rdr["Status"].ToString();
    
                    listataskova.Add(tas);
                }
            }
    
           // JavaScriptSerializer jm = new JavaScriptSerializer();
          //  Context.Response.Write(jm.Serialize(listataskova));
          return listataskova;
    }
