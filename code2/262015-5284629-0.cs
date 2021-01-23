    // stored as a private member
    private static Regex _checkId = new Regex(@"Id$", RegexOptions.Compiled);
    ...
    // inside some method
    column = _checkId.Replace(column, String.Empty);
