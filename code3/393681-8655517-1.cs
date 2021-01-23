    public static DataSet Osvezi(string naziv_tablice)
    {
            try
            {
                using (SqlConnection konekcija = new SqlConnection(ConfigurationManager.AppSettings["skripta"]))
                {
                    konekcija.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = konekcija;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Osvezi";
                        cmd.Parameters.AddWithValue("@tablica", naziv_tablice??DBNull.Value);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            // Fill the DataSet using default values for DataTable names, etc
                            DataSet dataset = new DataSet();
                            da.Fill(dataset);
                            return dataset;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                //Obravnava napak
            }
        return null;
    }
