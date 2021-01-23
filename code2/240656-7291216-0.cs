    // Define name/value pairs to be replaced.
    var replacements = new Dictionary<string, string>();
    replacements.Add("<Name>", client.FullName);
    replacements.Add("<EventDate>", event.EventDate.ToString());
    string s = "Dear <Name>, your booking is confirmed for the <EventDate>";
         
    // Parse the message into an array of tokens
    Regex regex = new Regex("(<[^>]+>)");
    string[] tokens = regex.Split(s);
    // Re-build the new message from the tokens
    var sb = new StringBuilder();
    foreach (string token in tokens)
       sb.Append(replacements.ContainsKey(token) ? replacements[token] : token);
    s = sb.ToString();
