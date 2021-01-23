    [SuppressMessage("Microsoft.Globalization", 
                     "CA1303:DoNotPassLiteralsAsLocalizedParameters", 
                     Justification="Exception are not localized")]
    public bool IsPageAccessible(string url, string documentId) {
      if (url == null) {
        throw new ArgumentNullException("url", @"url must not be null, use string.Empty if you don't care what the url is.");
      }
      if (documentId == null) {
        throw new ArgumentNullException("documentId", "documentId must not be null, use string.Empty if you don't care what the documentId is.");
      }
      return true;
    }
