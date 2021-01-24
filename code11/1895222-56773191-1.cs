    var templateId = (from o in db.PayrollTemplate
                          select new
                          {
                              o.TemplateId,
                              o.GradeId
                          }).ToList();
						  
		List<JsonResult> list = new List<JsonResult>();
        foreach (var items in templateId)
        {
            var empToRun = (from x in db.Employee
                            join y in db.SalaryInfo on x.Id equals y.EmployeeId
                            where x.GradeLevel == items.GradeId && x.Id == y.EmployeeId
                            select new
                            {
                                Id = x.Id
                            }).ToList();
            var empToCount = (from x in db.Employee
                              join y in db.SalaryInfo on x.Id equals y.EmployeeId
                              where x.GradeLevel == items.GradeId && x.Id == y.EmployeeId
                              select x).Count();
							  
            for (int i = 0; i <= empToCount;i++)
            {
                decimal payE = 0;
                var empId = empToRun[i].Id;
                var getGross = (from o in db.Employee
                                join a in db.SalaryInfo on o.Id equals a.EmployeeId
                                where o.Id == empId
                                select new
                                {
                                    GrossPay = a.GrossPay
                                }).FirstOrDefault();
                var percent = 20 * getGross.GrossPay;
                var twentyPercent = percent / 100;
                var cra = 200000 + twentyPercent;
                var taxAbleIncome = getGross.GrossPay - cra;
                if (taxAbleIncome >= 300000)
                {
                    var sevenPercent = (7 * 300000) / 100;
                    payE = sevenPercent;
                    taxAbleIncome = taxAbleIncome - 300000;
                }
                else
                {
                    var Yearly = "Year PayE: " + payE;
                    var pmonth = payE / 12;
                    var Monthly = "Monthly PayE: " + Math.Round(pmonth, 2);
                    var ret = Json(Yearly + " " + Monthly);
					list.add(ret);
					continue;
                }
                if (taxAbleIncome >= 300000)
                {
                    var elevenPercent = (11 * 300000) / 100;
                    payE = payE + elevenPercent;
                    taxAbleIncome = taxAbleIncome - 300000;
                }
                else
                {
                    var elevenPercent = (11 * taxAbleIncome) / 100;
                    payE = payE + (decimal)elevenPercent;
                    var Yearly = "Year PayE: " + payE;
                    var pmonth = payE / 12;
                    var Monthly = "Monthly PayE: " + Math.Round(pmonth, 2);
                    var ret = Json(Yearly + " " + Monthly);
					list.add(ret);
					continue;
                }
                if (taxAbleIncome >= 500000)
                {
                    var fifteenPercent = (15 * 500000) / 100;
                    payE = payE + fifteenPercent;
                    taxAbleIncome = taxAbleIncome - 500000;
                }
                else
                {
                    var fifteenPercent = (15 * taxAbleIncome) / 100;
                    payE = payE + (decimal)fifteenPercent;
                    var Yearly = "Year PayE: " + payE;
                    var pmonth = payE / 12;
                    var Monthly = "Monthly PayE: " + Math.Round(pmonth, 2);
                    var ret = Json(Yearly + " " + Monthly);
					list.add(ret);
					continue;
                }
                if (taxAbleIncome >= 500000)
                {
                    var nineteenPercent = (19 * 500000) / 100;
                    payE = payE + nineteenPercent;
                    taxAbleIncome = taxAbleIncome - 500000;
                }
                else
                {
                    var nineteenPercent = (19 * taxAbleIncome) / 100;
                    payE = payE + (decimal)nineteenPercent;
                    var Yearly = "Year PayE: " + payE;
                    var pmonth = payE / 12;
                    var Monthly = "Monthly PayE: " + Math.Round(pmonth, 2);
                    var ret = Json(Yearly + " " + Monthly);
					list.add(ret);
					continue;
                }
                if (taxAbleIncome > 1600000)
                {
                    var twentyonePercent = (21 * 1600000) / 100;
                    payE = payE + twentyonePercent;
                    taxAbleIncome = taxAbleIncome - 1600000;
                }
                else
                {
                    var twentyonePercent = (21 * 1600000) / 100;
                    payE = payE + twentyonePercent;
                    var Yearly = "Year PayE: " + payE;
                    var pmonth = payE / 12;
                    var Monthly = "Monthly PayE: " + Math.Round(pmonth, 2);
                    var ret = Json(Yearly + " " + Monthly);
					list.add(ret);
					continue;
                }
                if (taxAbleIncome > 3200000)
                {
                    var twentyfourPercent = (24 * 3200000) / 100;
                    payE = payE + twentyfourPercent;
                }
                else
                {
                    var twentyfourPercent = (21 * taxAbleIncome) / 100;
                    payE = payE + (decimal)twentyfourPercent;
                    var Yearly = "Year PayE: " + payE;
                    var pmonth = payE / 12;
                    var Monthly = "Monthly PayE: " + Math.Round(pmonth, 2);
                    var ret = Json(Yearly + " " + Monthly);
					list.add(ret);
					continue;
                }
                var Year = "Year PayE: " + payE;
                var Month = "Monthly PayE: " + payE / 12;
                var ret = Json(Year + " " + Month);
				list.add(ret);
            }
        }
		return list;
