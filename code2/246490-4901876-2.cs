    public int OutputMonthsOld(DateTime born)
            {
                DateTime dob = new DateTime(born.Year,born.Month,born.Day);
                DateTime today = DateTime.Today;
                
                int monthsAlive = -1;
    
                while (dob <= today)
                {
                    dob = dob.AddMonths(1);
                    monthsAlive++;
                }
    
                return monthsAlive;
            }
