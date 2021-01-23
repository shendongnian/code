       if (gYearRegex.IsMatch(tokens[pos]))
       {
          curYear = int.Parse(tokens[pos]);
       }
       else if (gMonthRegex.IsMatch(tokens[pos]))
       {
          curMonth = MyGlobals.GetMonthAsInt(tokens[pos]);
       }
       else if (gDayRegex.IsMatch(tokens[pos]))
       {
          string tok = tokens[pos];
          curDay = int.Parse(tok.Substring(0,(tok.Length-2)));
          // Dates are in reverse order, so using a stack means we'll pull em off in the correct order
          matchDateTimes.Push(new DateTime(curYear, curMonth, curDay));
       }
    }
    // Now get the datetimes in the correct order
    while (matchDateTimes.Count > 0)
    {
       // Do something with the dates
    }
}
