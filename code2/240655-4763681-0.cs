    // Define name/value pairs to be replaced.
    var replacements = new Dictionary<string,string>();
    replacements.Add("<Name>", client.FullName);
    replacements.Add("<EventDate>", event.EventDate.ToString());
    
    // Replace
    string s = "Dear <Name>, your booking is confirmed for the <EventDate>";
    foreach (var replacement in replacements)
    {
       s = s.Replace(replacement.Key, replacement.Value);
    }
