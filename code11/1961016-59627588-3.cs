    using (var cmd = _context.Database.GetDbConnection().CreateCommand()) {
        cmd.CommandText = "[Production].[Select_TicketQuantity]";
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
        cmd.Parameters.Add(new SqlParameter("Ticket", ticket));
        cmd.Parameters.Add(new SqlParameter("Reference", reference));
        quantity = (int)cmd.ExecuteScalar();
    }
