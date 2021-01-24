      public ActionResult ChartShow()
            {
    
                DateTime TM = DateTime.Now;
    
                DateTime FromDate1 = new DateTime(TM.Year, 01, 01);
                DateTime ToDate1 = new DateTime(FromDate1.Year, FromDate1.Month, DateTime.DaysInMonth(FromDate1.Year, FromDate1.Month));
                string S1 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate1 && (c.INDate) <= ToDate1 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate2 = new DateTime(TM.Year, 02, 01);
                DateTime ToDate2 = new DateTime(FromDate2.Year, FromDate2.Month, DateTime.DaysInMonth(FromDate2.Year, FromDate2.Month));
                string S2 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate2 && (c.INDate) <= ToDate2 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate3 = new DateTime(TM.Year, 03, 01);
                DateTime ToDate3 = new DateTime(FromDate3.Year, FromDate3.Month, DateTime.DaysInMonth(FromDate3.Year, FromDate3.Month));
                string S3 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate3 && (c.INDate) <= ToDate3 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate4 = new DateTime(TM.Year, 04, 01);
                DateTime ToDate4 = new DateTime(FromDate4.Year, FromDate4.Month, DateTime.DaysInMonth(FromDate4.Year, FromDate4.Month));
                string S4 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate4 && (c.INDate) <= ToDate4 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate5 = new DateTime(TM.Year, 05, 01);
                DateTime ToDate5 = new DateTime(FromDate5.Year, FromDate5.Month, DateTime.DaysInMonth(FromDate5.Year, FromDate5.Month));
                string S5 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate5 && (c.INDate) <= ToDate5 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate6 = new DateTime(TM.Year, 06, 01);
                DateTime ToDate6 = new DateTime(FromDate6.Year, FromDate6.Month, DateTime.DaysInMonth(FromDate6.Year, FromDate6.Month));
                string S6 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate6 && (c.INDate) <= ToDate6 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate7 = new DateTime(TM.Year, 07, 01);
                DateTime ToDate7 = new DateTime(FromDate7.Year, FromDate7.Month, DateTime.DaysInMonth(FromDate7.Year, FromDate7.Month));
                string S7 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate7 && (c.INDate) <= ToDate7 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate8 = new DateTime(TM.Year, 08, 01);
                DateTime ToDate8 = new DateTime(FromDate8.Year, FromDate8.Month, DateTime.DaysInMonth(FromDate8.Year, FromDate8.Month));
                string S8 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate8 && (c.INDate) <= ToDate8 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate9 = new DateTime(TM.Year, 09, 01);
                DateTime ToDate9 = new DateTime(FromDate9.Year, FromDate9.Month, DateTime.DaysInMonth(FromDate9.Year, FromDate9.Month));
                string S9 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate9 && (c.INDate) <= ToDate9 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate10 = new DateTime(TM.Year, 10, 01);
                DateTime ToDate10 = new DateTime(FromDate10.Year, FromDate10.Month, DateTime.DaysInMonth(FromDate10.Year, FromDate10.Month));
                string S10 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate10 && (c.INDate) <= ToDate10 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate11 = new DateTime(TM.Year, 11, 01);
                DateTime ToDate11 = new DateTime(FromDate11.Year, FromDate11.Month, DateTime.DaysInMonth(FromDate11.Year, FromDate11.Month));
                string S11 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate11 && (c.INDate) <= ToDate11 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                DateTime FromDate12 = new DateTime(TM.Year, 12, 01);
                DateTime ToDate12 = new DateTime(FromDate12.Year, FromDate12.Month, DateTime.DaysInMonth(FromDate12.Year, FromDate12.Month));
                string S12 = db.TBLInvoices.Where(c => (c.INDate) >= FromDate12 && (c.INDate) <= ToDate12 && c.INActive == true).Sum(c => c.INTotal).GetValueOrDefault().ToString();
    
                string[] Modes = { S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12 };
                ViewData["OurSals"] = Modes;
    
                return View();
            }
