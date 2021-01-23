    public string ConvertAge(DateTime dateOfBirth)
            {
                int daysOld = (DateTime.Now - dateOfBirth).Days;
                int yearsOld = OutputYearsOld(dateOfBirth);
    
                if (yearsOld >= 2)
                {
                    return String.Format("{0:0##}{1}", yearsOld, 'Y');
                }
                else if (OutputMonthsOld(dateOfBirth) > 6)
                {
                    return String.Format("{0:0##}{1}", OutputMonthsOld(dateOfBirth),
                    'M');
                }
                else if (daysOld > (7*6))
                {
                    return String.Format("{0:0##}{1}", daysOld / 7, 'W');
                }
                else
                {
                    return String.Format("{0:0##}{1}", daysOld, 'D');
                }
            }
