    DateTime dt;
    if(DateTime.TryParseExact(readInString, "yyyy-MM-dd", null, DateTimeStyles.AssumeLocal, out dt))
    {
      if(dt != DateTime.Now.Date)
      {
        //Code for case where it's no longer that day goes here.
      }
    }
    else
    {
      //Code for someone messed up the file and it's not a valid date any more goes here.
    }
