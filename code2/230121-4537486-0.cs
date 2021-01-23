    dates = new List<DateTime>
                {
                    DateTime.Now.AddHours(-1),
                    DateTime.Now.AddHours(-2),
                    DateTime.Now.AddHours(-3)
                };
                dates.Sort((x, y) => DateTime.Compare(x.Date, y.Date)); 
                DateTime dateToCheck = DateTime.Now.AddMinutes(-120);
                int place = apply_the_algorythm(dateToCheck);
                Console.WriteLine(dateToCheck.ToString() + " is in interval :" +(place+1).ToString());
    private int apply_the_algorythm(DateTime date)
            {
                if (dates.Count == 0)
                    return -1;
                for (int i = 0; i < dates.Count; i++)
                {
                    // check if the given date does not fall into any range.
                    if (date < dates[0] || date > dates[dates.Count - 1])
                    {
                        return -1;
                    }
                    else
                    {
                        if (date >= dates[i]
                            && date < dates[i + 1])
                            return i;
                    }
                }
                return dates.Count-1;
            }
