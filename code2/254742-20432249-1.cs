    public static string TextFollowing(string searchTxt, string value) {
      if (!String.IsNullOrEmpty(searchTxt) && !String.IsNullOrEmpty(value)) {
        int index = searchTxt.IndexOf(value);
        if (-1 < index) {
          int start = index + value.Length;
          if (start <= searchTxt.Length) {
            return searchTxt.Substring(start);
          }
        }
      }
      return null;
    }
