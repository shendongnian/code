        public static double Yearfrac(DateTime startDate,DateTime endDate,DayCount daycount=DayCount.ActAct)
        {
            var nbDaysInPeriod = (double)(endDate - startDate).Days;
            
            switch(daycount)
            {
                case (DayCount.Act360):
                    return nbDaysInPeriod / (double)360;
                case (DayCount.Act365):
                    return nbDaysInPeriod / (double)365;
                case (DayCount.ActAct):
                    return GetActAct(startDate,endDate);
                case (DayCount.Days360):
                    var result = (endDate.Year - startDate.Year) * 360.0 + (endDate.Month - startDate.Month) * 30.0 + (Math.Min(endDate.Day, 30.0) - Math.Min(startDate.Day, 30.0));
                    return result/360;
                default:
                    return nbDaysInPeriod / (double)365;
            }
        }
        public static double GetActAct(DateTime startDate, DateTime endDate)
        {
            // Reproduce Excel Yearfrac as per http://www.dwheeler.com/yearfrac/excel-ooxml-yearfrac.pdf
            var nbDaysInPeriod = (double)(endDate - startDate).Days;
            if(startDate.Year==endDate.Year || (endDate.Year-1==startDate.Year&&(startDate.Month>endDate.Month||startDate.Month==endDate.Month&&(startDate.Day>=endDate.Day))))
            {
                var den =  365.0;
                if (startDate.Year == endDate.Year && DateTime.IsLeapYear(startDate.Year))
                {
                    den++;
                }
                else
                {
                    
                    if (endDate.Day == 29 && endDate.Month == 2)
                    {
                        den++;
                    }
                    else
                    {
                        if (DateTime.IsLeapYear(startDate.Year))
                        {
                            var feb = new DateTime(startDate.Year, 2, 29);
                            if (startDate<=feb && feb<=endDate) den++;
                        }
                        else
                        {
                            if (DateTime.IsLeapYear(endDate.Year))
                            {
                                var feb = new DateTime(endDate.Year, 2, 29);
                                if (startDate <= feb && feb <= endDate) den++;
                            }
                        }
                    }
                }
            }
            else
            {
                var nbYears = endDate.Year - startDate.Year+1;
                var den = nbYears * 365.0;
                for (var i=0;i<nbYears;i++)
                {
                    if (DateTime.IsLeapYear(startDate.Year + i)) den++;
                }
                den /= nbYears;
                return nbDaysInPeriod / den;
            }
            return nbDaysInPeriod / 365.0;
        }
