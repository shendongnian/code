      private bool UpdateEleve(string name, string key) {
        int matricule;
        // RDBMS want's int, mot string; let's ensure it
        if (!int.TryParse(key), out matricule) 
          return false;
        // wrap IDisposable into using 
        using (SqlConnection con = new SqlConnection(...)) {
          con.Open();
          // Keep queries readable and paramterized
          string query =
            @"update eleve 
                 set nom = @prm_Nom
               where matricule = @prm_Matricule";
          using (var q = new SqlCommand(query, con)) {
            //TODO: q.Parameters.Add("@prm_Nom", RDMBS_TYPE).Value = ... is a better choice
            // I've put AddWithValue since I don't know RDMBS_TYPE
            q.Parameters.AddWithValue("@prm_Nom", name);
            q.Parameters.AddWithValue("@prm_Matricule", matricule);
            q.ExecuteNonQuery();
            return true;
          }
        } 
      }
