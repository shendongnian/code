    // define/read connection string and SQL statement
    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    string sqlStatement = "UPDATE ConferenceRole SET Role_ID = @RoleID, " +
                          "Person_ID = @PersonID, " + 
                          "WHERE Conference_ID = @ConferenceID AND Track_ID = @TrackID";
    // put your SqlConnection and SqlCommand into using blocks!
    using(SqlConnection _con = new SqlConnection(connectionString))
    using(SqlCommand _cmd = new SqlCommand(sqlStatement, _con))
    {
       // define and set parameter values
       _cmd.Parameters.Add("@RoleID", SqlDbType.INT).Value = 3;
       _cmd.Parameters.Add("@PersonID", SqlDbType.INT).Value = idp;
       _cmd.Parameters.Add("@ConferenceID", SqlDbType.INT).Value = conference;
       _cmd.Parameters.Add("@TrackID", SqlDbType.INT).Value = trackId;
       // execute query 
       _con.Open();
       _cmd.ExecuteNonQuery();
       _con.Close();
    }
