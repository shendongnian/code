    using (MyDataContext TheDC = new MylDataContext())
    {
       var TheOutput = from a in TheDC.MyTable
         where a.UserID == TheUserID &&   
         (a.Date1.Month == TheDate.Month && a.Date1.Year == TheDate.Year)
         ||
         ( a.Date2.Month == TheDate.Month && a.Date2.Year == TheDate.Year)
         group a by a.Date1.Date AND by a.Date2.Date into daygroups
         select new MyModel{...};
