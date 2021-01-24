       class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args) 
            {
                DataTable utcDT = new DataTable("utcDT");
                utcDT.Columns.Add("Date", typeof(DateTime));
                utcDT.Columns.Add("Value", typeof(decimal));
                utcDT.Rows.Add(new object[] { DateTime.Parse("1/28/2016 00:02:00"), 123.97 });
                utcDT.Rows.Add(new object[] { DateTime.Parse("1/28/2016 00:03:00"), 123.76 });
                utcDT.Rows.Add(new object[] { DateTime.Parse("1/28/2016 00:04:00"), 123.74 });
                utcDT.Rows.Add(new object[] { DateTime.Parse("1/28/2016 00:06:00"), 123.81 });
                utcDT.Rows.Add(new object[] { DateTime.Parse("1/28/2016 00:07:00"), 123.74 });
                utcDT.Rows.Add(new object[] { DateTime.Parse("1/28/2016 00:08:00"), 123.81 });
                utcDT.Rows.Add(new object[] { DateTime.Parse("1/28/2016 00:12:00"), 123.5 });
                DateTime minTime = utcDT.AsEnumerable().Min(x => x.Field<DateTime>("Date"));
                DateTime maxTime = utcDT.AsEnumerable().Max(x => x.Field<DateTime>("Date"));
                int totalMinutes = maxTime.Subtract(minTime).Minutes;
                List<DateTime> newDates = Enumerable.Range(0, totalMinutes + 1).Select(x => minTime.AddMinutes(x)).ToList();
                DataTable cloneTable = utcDT.Clone();
                var join = from nDate in newDates 
                           join  row in utcDT.AsEnumerable() on nDate equals row.Field<DateTime>("Date") into emptyRow
                           from row in emptyRow.DefaultIfEmpty() 
                           select new { row = row, date = nDate };
                decimal lastValue = 0.0M;
                foreach (var joinRow in join)
                {
                    if (joinRow.row == null)
                    {
                        cloneTable.Rows.Add(new object[] { joinRow.date, lastValue });
                    }
                    else
                    {
                        cloneTable.Rows.Add(joinRow.row.ItemArray);
                        lastValue = joinRow.row.Field<decimal>("Value");
                    }
                }
     
            }
        }
