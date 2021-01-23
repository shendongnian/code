    void test(string BeginDate, string EndDate) {
      DateTime noDate = new DateTime(1900, 1, 1);
      DateTime b;
      DateTime e;
      try {
        b = Convert.ToDateTime(BeginDate);
      } catch (Exception error) {
        b = noDate;
        MessageBox.Show("Invalid Format: " + BeginDate);
      }
      try {
        e = Convert.ToDateTime(EndDate);
      } catch (Exception error) {
        e = noDate;
        MessageBox.Show("Invalid Format: " + EndDate);
      }
      if (e < b) {
        throw new Exception("End Date can not be before Begin Date.");
      }
    }
