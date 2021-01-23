        public static int MonthDiff(DateTime d1, DateTime d2){
            int retVal = 0;
            if (d1.Month<d2.Month)
            {
                retVal = (d1.Month + 12) - d2.Month;
                retVal += ((d1.Year - 1) - d2.Year)*12;
            }
            else
            {
                retVal = d1.Month - d2.Month;
                retVal += (d1.Year - d2.Year)*12;
            }
            //// Calculate the number of years represented and multiply by 12
            //// Substract the month number from the total
            //// Substract the difference of the second month and 12 from the total
            //retVal = (d1.Year - d2.Year) * 12;
            //retVal = retVal - d1.Month;
            //retVal = retVal - (12 - d2.Month);
            return retVal;
        }
