    public Sifrarnik ChangeOpisText(string opis)
    {
        using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Cloud"].ConnectionString))
        {
            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }
            var response = db.Query<Sifrarnik>
            (
                "dbo.spChangeOpisText @opis",
                new
                {
                    opis = opis
                }
            )
            .Single();
            return response;
        }
    }
