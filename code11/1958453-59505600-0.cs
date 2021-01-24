        public int GetAge(string DOB)
            {
                DateTime startDate = new Date();
                int driverAge = startDate.Year - DateTime.Parse(DOB).Year;
        
                if (startDate.Month < DateTime.Parse(DOB).Month || (startDate.Month == DateTime.Parse(DOB).Month && startDate.Day < DateTime.Parse(DOB).Day))
                {
                    driverAge--;
        
                }
                    return driverAge;
        
            }
