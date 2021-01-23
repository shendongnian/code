    //Call this by passing values from configuration
    private string GetNiceLookingLable(int? years, int? months, int? days){
        var yearMessage = (years.HasValue)?String.Format("{0} Years", years):String.Empty;
        var monthMessage = (months.HasValue)?String.Format("{0} Months", months):String.Empty;
        var daysMessage = (days.HasValue)?String.Format("{0} Days", days):String.Empty;
        // You probably want to concatenate them properly
        return String.Format("{0} {1} {2}",yearMessage, monthMessage, daysMessage);
    }
-
    //Call this to get starting date
    private DateTime getStartingDate(int? years, int? months,int? days){
         var retDate = DateTime.Today;
         if(years.HasValue){
             retDate = retDate.AddYears(-1*years.Value);
         }
         if(months.HasValue){
             retDate = retDate.AddMonths(-1*months.Value);
         }
         if(days.HasValue){
             retDate = retDate.AddDays(-1*days.Value);
         }
         return retDate;
    }
