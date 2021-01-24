    private DataTable GetComboDates() {
      DataTable dt = GetComboTable();
      Random rand = new Random();
      int duration = 5 * 365;          
      DateTime randomDate = DateTime.Today.AddDays(-rand.Next(duration));
      for (int i = 0; i < 10; i++) {
        dt.Rows.Add(randomDate, String.Format("{0:yyy/MM/dd - hh:mm:ss tt}", randomDate));
        randomDate = DateTime.Today.AddDays(-rand.Next(duration));
      }
      return dt;
    }
