    public string ConvertAge(DateTime dateOfBirth)
            {
                int daysOld = (DateTime.Now - dateOfBirth).Days;
                //Age < 6 Weeks
                if (daysOld < (6 * 7)) 
                    return String.Format("{0:0##}{1}", daysOld, 'D'); 
                //Age < 6 Months
                else if (daysOld < (6 * 31)) 
                    return String.Format("{0:0##}{1}", daysOld/7, 'W');
                //Age < 2 Years
                else if (daysOld < (2 * 365)) 
                    return String.Format("{0:0##}{1}", daysOld / 31, 'M');
                //Age >= 2 Years
                else 
                    return String.Format("{0:0##}{1}", daysOld / 365, 'Y');
            }
