    > Random gen = new Random();
    > DateTime RandomDay()
    . {
    .     int monthsBack = 1;
    .     int monthsForward = 3;
    .     DateTime startDate = DateTime.Now.AddMonths(-monthsBack);
    .     DateTime endDate = DateTime.Now.AddMonths(monthsForward);    
    .     int range = (endDate - startDate).Days;
    .     return startDate.AddDays(gen.Next(range));
    . }
    > RandomDay()
    [28/01/2020 15:11:51]
