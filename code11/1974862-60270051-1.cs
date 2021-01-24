    public static bool SavePerson(int idUtente, string nome, string orario)
    {
        using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        {
            var output = cnn.Query($"select * from utenti where id = {idUtente}").FirstOrDefault();
            if (output != null) {
                nome = FindCognome(idUtente);
                var checkpresenza = cnn.QuerySingle<int>($"select presente from utenti where id = \"{idUtente}\" limit 1");
                Console.WriteLine(checkpresenza);
                if (checkpresenza == 0)
                {
                    cnn.Execute($"INSERT INTO entrate (id_utente, nome, entrata) VALUES (\"{idUtente}\",\"{nome}\",\"{orario}\")");
                    cnn.Execute($"UPDATE utenti SET presente = \"1\"  WHERE id = {idUtente}");
                    presenza = 0;
                }
                else if (checkpresenza == 1)
                {
                    cnn.Execute($"UPDATE entrate SET uscita = \"{orario}\" where id_utente = {idUtente}");
                    cnn.Execute($"UPDATE utenti SET presente = \"0\"  WHERE id = {idUtente}");
                    presenza = 1;
                }
                cnn.Close();
                return true;
            } 
            else return false;
                
            }
       
    }
