var days = new HashSet(EachDay(dateTimePickerFrom.Value, dateTimePickerTo.Value).Select(day=>day.ToString("yyyy-MM-dd")))
var dates = dataGridViewTrip.Rows
               .Where(row => days.Contains(row.Cells[0].Value)) //select only dates from picker
               .GroupBy(r=>DateTime.Parse(row.Cells[0].Value)); // group by date
foreach(var date in dates ) // iterate over dates to calculate p
{
  var totalpassengerDaily = 0;
  var totalCommission = 0;
  var times = date.GroupBy(r=>DateTime.Parse(r.Cells[1].Value).TimeOfDay) // group by time
                  .OrderBy(r=>g.Key) // sort by time
                  .Select(g=> new { Time = g.Key,
                            TotalpassengerDaily=(totalpassengerDaily +=g.Sum(int.Parse(row.Cells[4].Value.ToString()))),
                            TotalCommission =(totalCommission +=g.Sum(Decimal.Parse(row.Cells[8].Value.ToString())))});
// it takes only existing times, if you need to fill gaps 
// just use for loop to iterate over all minutes
  foreach(time in times) {
    chartDaily.Series["Passengers"].Points.AddXY(time.Time, time.TotalpassengerDaily);
    chartDaily.Series["Commission"].Points.AddXY(time.Time, time.TotalCommission );
    DataRow row = summaryReport.NewRow();
    row["Date"] = counterTime;
    row["Passenger"] = time.TotalpassengerDaily;
    row["Commission"] = time.TotalCommission;
    summaryReport.Rows.Add(row);
  }
                 
}
