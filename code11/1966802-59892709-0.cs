    private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
     protected void txtDate_TextChanged1(object sender, EventArgs e)
    {
      DateTime startDate  = DateTime.ParseExact(app.GetdateMMDDYYYY(txtDate.Text), "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture);
      
     string yearInTheFuture = Convert.ToString(Convert.ToDateTime(startDate).AddYears(1));
     txtEndDate.Text = Convert.ToDateTime(yearInTheFuture).ToString("dd/MM/yyyy");
    }
