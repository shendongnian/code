    private void dtpDOB_Leave(object sender, System.EventArgs e) {
      System.DateTime dob = default(System.DateTime);
      dob = dtpDob.Value.Date;
      int age = -1;
      DateTime today = DateTime.Today;
      while (dob <= today) {
        age++;
        dob = dob.AddYears(1);
      }
      txtAge.Text = age.ToString();
    }
