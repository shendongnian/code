    private void Form1_Load(object sender, EventArgs e)
            {
    
                List<DateTime> CompleteListOfDates = new List<DateTime>();
    
                CompleteListOfDates.Add(new DateTime(2011, 1, 1));
                CompleteListOfDates.Add(new DateTime(2011, 1, 5));
                CompleteListOfDates.Add(new DateTime(2011, 3, 1));
                CompleteListOfDates.Add(new DateTime(2011, 5, 1));
                CompleteListOfDates.Add(new DateTime(2011, 5, 1));
                CompleteListOfDates.Add(new DateTime(2012, 1, 1));
                CompleteListOfDates.Add(new DateTime(2012, 2, 1));
    
                List<DateTime> UniqueMonthYears = 
                    CompleteListOfDates.Select(t => 
                        GetDateHash(t)).Distinct().Select(t => 
                            CreateFromDateHash(t)).ToList();
                   
    
                MessageBox.Show(UniqueMonthYears.Count.ToString());
            }
    
            private static string GetDateHash(DateTime date)
            {
                return date.ToString("MMM-yyyy");
            }
    
            private static DateTime CreateFromDateHash(string hash)
            {
                return DateTime.Parse("1-" + hash);
            }
