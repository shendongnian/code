        public string YearsMonthsDaysDiff(DateTime dateFrom, DateTime dateTo)
        {
            Int32 mD = DateTime.DaysInMonth(dateTo.Year, dateTo.AddMonths(-1).Month); //first check out days in month before dateTo month
            Int32 D1 = dateFrom.Day;
            Int32 M1 = dateFrom.Month;
            Int32 Y1 = dateFrom.Year;
            Int32 D2 = dateTo.Day;
            Int32 M2 = dateTo.Month;
            Int32 Y2 = dateTo.Year;
            // Substract each datetime components accordingly
            D2 -= D1;
            M2 -= M1;
            Y2 -= Y1;
            if (D2 < 0)
            {
                D2 += mD;// D2 is less then D1, then add mD
                M2 -= 1; // but, substract 1 from M2 
            }
            if (M2 < 0)
            {
                M2 += 12; // if M2 is less then M1, then add with 12
                Y2 -= 1; // but substract 1 from Y2 
            }
            return Y2.ToString("## years ") + M2.ToString("##  months ") + D2.ToString("## days");
        }
