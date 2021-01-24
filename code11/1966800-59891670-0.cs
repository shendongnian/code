     protected void txtDate_TextChanged1(object sender, EventArgs e)
    {
        var dutchCultureInfo = CultureInfo.CreateSpecificCulture("nl-NL");
        DateTime startDate = DateTime.ParseExact(txtDate.Text, "dd.MM.yyyy", dutchCultureInfo);
       
        //var date1 = DateTime.ParseExact(startDate, "dd.MM.yyyy", dutchCultureInfo);
        string yearInTheFuture = Convert.ToString(Convert.ToDateTime(startDate).AddYears(1));
        //yearInTheFuture = app.GetdateMMDDYYYY(yearInTheFuture).ToString();
        txtEndDate.Text = Convert.ToDateTime(yearInTheFuture).ToString("dd/MM/yyyy");
    }
