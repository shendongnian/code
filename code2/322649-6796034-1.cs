    using (clientsDBDataContext clientDB = new clientsDBDataContext()) {
        var client = clientDB.clientURIs.Where(c => c.clientID == clientID).Single();
        client.uri = uri.ToString();
        clientDB.SubmitChanges();
    }
