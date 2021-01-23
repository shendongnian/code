    var client = new ServiceFairy.clientURI();
    foreach (string r in client.uri)
    {
        Uri rs = new Uri(r.ToString());
        SendMessage(rs, messageBytes, NotificationType.Toast);
    }
