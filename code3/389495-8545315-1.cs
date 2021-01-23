    SqlParameter checkin = new SqlParameter("@CheckInDate", SqlDbType.DateTime);
    SqlParameter checkout = new SqlParameter("@CheckOutDate", SqlDbType.DateTime);
    
    checkin.Value = DateTime.Today; // Format these to the desired dates
    checkout.Value = DateTime.Today;
    
    command.Parameters.Add(checkin);
    command.Parameters.Add(checkout);
