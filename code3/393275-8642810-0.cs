    using System.Globalization;
    
                  
         string date = TextBox1.Text.Trim().ToUpper();
                    Date Time myDate= DateTime.ParseExact(date, "ddMMMyy", CultureInfo.InvariantCulture);
                    DatePicker1.Value = myDate;
