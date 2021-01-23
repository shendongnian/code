    string myDate = browser.TextField(Find.ByName("myTextField")).Value;
    DateTime time =  = new DateTime();
    if(DateTime.TryParse(myDate, out time);) {
         Console.WriteLine(time.Month);
    }
    else {
       //Not a valid date.
    }
