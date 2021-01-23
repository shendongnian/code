    public static string TextFollowing(this string txt, string value) {
      if (!String.IsNullOrEmpty(txt) && !String.IsNullOrEmpty(value)) {
        int index = txt.IndexOf(value);
        if (-1 < index) {
          int start = index + value.Length;
          if (start <= txt.Length) {
            return txt.Substring(start);
          }
        }
      }
      return null;
    }
