            Calendar cal =  Calendar.ReadOnly(CultureInfo.CurrentCulture.Calendar);
            StringBuilder sb = new StringBuilder(); 
            DirectoryInfo rdi = new DirectoryInfo(Root);  // get all files in the root directory
            List<FileInfo> allfis = rdi.GetFiles("*", SearchOption.AllDirectories).ToList();
            var a = allfis.GroupBy(q=>cal.GetYear(q.LastWriteTime)); 
            foreach (var b in a.Where(q=>q.Key==2011)) // this year only
            {
                double yearStartOaDate = new DateTime(b.Key, 1, 1).ToOADate();
                double yearEndOaDate = yearStartOaDate + 365;
                // get exact start dates for each week
                Dictionary<int, DateTime> weekStartingDates = new Dictionary<int, DateTime>();
                while (yearStartOaDate <= yearEndOaDate)
                {
                    DateTime dt = DateTime.FromOADate(yearStartOaDate);
                    int ww = cal.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                    if(!weekStartingDates.ContainsKey(ww))
                    {
                        weekStartingDates.Add(ww, dt);
                    }
                    yearStartOaDate += ww == 1 ? 1 : 7;
                }
                var c = b.GroupBy(q => cal.GetWeekOfYear(q.LastWriteTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday)).OrderBy(q=>q.Key);
                foreach(var d in c)
                {
                    sb.AppendLine("Between " + weekStartingDates[d.Key].ToShortDateString() + " and " + weekStartingDates[d.Key].AddDays(6).ToShortDateString() + " there were " + d.Count() + " files modified");
                }
            }
            File.WriteAllText("results.txt", sb.ToString());
