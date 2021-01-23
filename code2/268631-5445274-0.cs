    Guid currentUserId = (Guid)(Membership.GetUser(User.Identity.Name).ProviderUserKey);
    using (var connection = new SqlConnection("..."))
    using (var command = connection.CreateCommand())
    {
        command.CommandText = "INSERT INTO Accom (UserID) VALUES (@UserID)";
        var param = command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
        param.Value = currentuserId;
        connection.Open();
        command.ExecuteNonQuery();
    }
