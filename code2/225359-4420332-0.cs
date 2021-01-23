    string sql = "Your current SQL here";
    string connectionString = "Your connection string here";
    // The using block ensures that the connection will be closed and freed up,
    //  even if an unhandled exception occurs inside the block.
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
      SqlCommand cmd = new SqlCommand(sql, conn);
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();
      da.Fill(dt);
      AllBrandsRptr.DataSource = dt;
      AllBrandsRptr.DataBind();
      var cuisineTypes = from row in dt.AsEnumerable()
                         select row["CuisineType"];
      string cuisines = string.Join(", ", cuisineTypes.Distinct());
      var venueTypes = from row in dt.AsEnumerable()
                       select row["VenueTypeName"];
      string venues = string.Join(", ", venueTypes.Distinct());
    }
