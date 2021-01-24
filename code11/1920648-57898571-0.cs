var today = DateTime.Now;
var ticksPerFiveSeconds = DateTime.Now.AddSeconds(5).Ticks - DateTime.Now.Ticks;
var twentyYearsFromNow = today.AddYears(20);
var todayTicks = today.Ticks;
var twentyYearsFromNowTicks = twentyYearsFromNow.Ticks;
var listofdate = new List<DateTime>();
var timer = new System.Timers.Timer();
timer.Start();
while (todayTicks <= twentyYearsFromNowTicks)
{
    listofdate.Add(new DateTime(todayTicks));
    todayTicks = todayTicks + ticksPerFiveSeconds;
}
timer.Stop();
Console.WriteLine("ticks :" + timer.Interval);
Console.Read();
