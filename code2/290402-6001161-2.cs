    public DataTable GetCustomers(DataTime datefrom, DataTime dateto)
    {
    	var sql = @"
    		SELECT customerid, firstname, lastname, telephone, email
    		FROM customer
    		JOIN booking
    			ON customer.customerid = booking.customerid
    		WHERE bookstartdate BETWEEN '" + ReturnDbDate(datefrom).ToString() + "' AND '" + ReturnDbDate(dateto).ToString() + "'";
    		
    	using (SqlConnection conn = new SqlConnection(connstring))
    	using (SqlDataAdapter ad = new SqlDataAdapter(sql, conn))
    	{
    			DataSet ds = new DataSet();
    			ad.Fill(ds);
    			return ds.tables[0];
    	}
    }
