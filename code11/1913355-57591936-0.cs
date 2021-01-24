    bool parsed = false;
    DateTime outDate;
    parsed = DateTime.TryParseExact(inputDate, "dd-MM- 
     yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, 
     out outDate);
     if(parsed)
     {
      usr.DogumTarihi = outDate.ToString("yyyy-MM-dd");
      }
     else
     {
       // Invalid date has been passed
     }
