    using System.Data.Objects.SqlClient; //Don't forget this!!
    
    //You can access to SQL DatePart function using something like this:
    
    YourTable.Select(t => new { DayOfWeek = SqlFunctions.DatePart("weekday", t.dateTimeField) - 1 }); //Zero based in SQL
    
    //You can compare to SQL DatePart function using something like this:
    
    DateTime dateToCompare = DateTime.Today;
    YourTable.Where(t => SqlFunctions.DatePart("weekday", t.dateTimeField) - 1 == dateToCompare }); //Zero based in SQL
