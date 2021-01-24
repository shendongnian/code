    public DateTime AddDaysOrMonths(string input, DateTime dt)
    {
         Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
         Match result = re.Match(input);
         string alphaPart = result.Groups[1].Value;
         string numberPart = result.Groups[2].Value;
         
         if(alphaPart == "DD")
         {
           int days;
           if(Integer.TryParse(numberPart,out days) == true)
           {
               dt.AddDays(days)
           }
         }
         else if (alphaPart == "MM")
         {
           int months;
           if(Integer.TryParse(numberPart,out months) == true)
           {
               dt.AddMonths(months);
           }
         }
        return dt;
    }
