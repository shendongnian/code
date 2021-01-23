    static char DATESPLITTER = '/'; // define this accordingly
    static DateTime NODATE = new DateTime(1, 1, 1900);
    private DateTime GetDate(string dateValue) {
      if (!String.IsNullOrEmpty(dateValue) {
        string[] split = dateValue.Split(DATESPLITTER);
        if (split.Length == 3) {
          int m = Convert.ToInt32(split[0]);
          if ((0 < m) && (m < 13)) {
            int d = Convert.ToInt32(split[1]);
            if ((0 < d) && (d < 32)) {
              int y = Convert.ToInt32(split[2]);
              if ((0 < y) && (y < DateTime.Now.Year)) {
                if (y < 100) y += 2000;
                return new DateTime(m, d, y);
              }
            }
          }
        }
      }
      return NODATE;
    }
