    using (SqlCommand comm = new SqlCommand("select max(FlightBookingID) from dbo.FlightBookingDetails", FlyCon))
    {
        var result = comm.ExecuteScalar();
        if (!Convert.IsDBNull(result))
            Session["FBookingID"] = result;
    }
