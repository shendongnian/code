    string rawMilliseconds = Request.QueryString["expiry"];
    if (string.IsNullOrWhiteSpace(rawMilliseconds))
        throw new InvalidOperationException("Expiry is null or empty!");
    long milliseconds;
    if (!long.TryParse(rawMilliseconds, out milliseconds))
        throw new InvalidOperationException("Unable to parse expiry!");
    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    DateTime expiry = epoch.AddMilliseconds(milliseconds);
