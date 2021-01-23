    public static bool IsValidHttpUri(string uriString)
    {
      Uri test = null;
      return Uri.TryCreate(uriString, UriKind.Absolute, out test) && test.Scheme == "http";
    )
