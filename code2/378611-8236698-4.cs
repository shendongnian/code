    /// <summary>
    /// Like string.Format but takes "{named}" identifiers with a Dictionary
    /// of replacement values.
    /// </summary>
    /// <param name="format"></param>
    /// <param name="replaces"></param>
    /// <returns></returns>
    public static string Format(string format, IDictionary<string,object> replaces) {
        if (format == null) throw new ArgumentNullException("format");
        if (replaces == null) throw new ArgumentNullException("replaces");
        return Regex.Replace(format, @"{(?<key>\w+)(?:[:](?<keyFormat>[^}]+))?}", (match) => {
            Object value;
            var key = match.Groups["key"].Value;
            var keyFormat = match.Groups["keyFormat"].Value;
            if (replaces.TryGetValue(key, out value)) {
                if (string.IsNullOrEmpty(keyFormat)) {
                    return "" + value;
                } else {
                    // format if applicable
                    return string.Format("{0:" + keyFormat + "}", value);
                }
            } else {
                // don't replace not-found
                return match.Value;
            }
        });
    }
