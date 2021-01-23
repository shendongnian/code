    DateTime input;
    if(DateTime.TryParse(txt_SendAt.Text, 
                         CultureInfo.InvariantCulture, 
                         DateTimeStyles.None, 
                         out input))
    {
      if(input <= DateTime.Now)
      {
        // your code here
      }
    }
    else
    {
     //not a valid DateTime string
    }
