    public class DateController : Controller
    {
     
      public ActionResult date()
        {
            int allDiff;
            List<int> list=new List<int>();
            int flag = 0;
            int conflict = 0;
            List<int> conf = new List<int>();
            conf.Add(0);
            int a = 0;
            DateTime[] startDate = new DateTime[3];
            startDate[0] = new DateTime(2011, 11, 5);
            startDate[1] = new DateTime(2011, 11,7);
            startDate[2] = new DateTime(2011, 11, 15);
    
            DateTime[] endDate = new DateTime[3];
            endDate[0] = new DateTime(2011, 11, 10);
            endDate[1] = new DateTime(2011, 11,12);
            endDate[2] = new DateTime(2011, 11, 20);
       
            DateTime Min= startDate.Min();
            DateTime Max = endDate.Max();
            TimeSpan span = Max - Min;
            int total = span.Days;
            ViewBag.globalTotal = total;
            foreach (DateTime e in endDate)
            {
            
                foreach (DateTime s in startDate)
                {
                    if (s >= e)
                    {
                        TimeSpan span1 = s - e;
                        allDiff = span1.Days;                    
                        list.Add(allDiff);
                        flag = 1;
                        conflict = 1;
                    }
                    else {
                        flag = 0;
                    }
                }
                if((list.Count==1)&&(conflict==1)&&(list!=null)){
                     a = list[0];
                    conf.Add(a);
                }
                if ((flag == 1)&&(list.Count>1))
                {
                    int m = list.Min();
                    ViewBag.dhiraj = m;
                    total = total - m;
                    list.Clear();
                }
                            
            }
            int confl= conf.Min();
            total=total-confl;
            ViewBag.Total = total;
        
            return View();
        }
    }
}
`
