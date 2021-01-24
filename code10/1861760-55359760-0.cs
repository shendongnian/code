                string lblweekoff = "Sunday,Saturday";
                string txtDate = "3/30/2019";
                var dayColumns = new[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
                List<string> weekday = new List<string>();
                weekday.AddRange(lblweekoff.Split(','));
                foreach(var cc in weekday)
                {
                    var weekoff = dayColumns.Where(x=>x==cc).First();
                    DateTime Date = Convert.ToDateTime(txtDate);
                    if (Date.DayOfWeek.ToString() == weekoff)
                    {
                      
                    }
                    else
                    {
                      
                    }
                }
