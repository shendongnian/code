      public static class currency_helpers {
        public static DateTime UNIXTimeToDateTime(this int unix_time) {
          return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unix_time).ToLocalTime();
        }
      }
