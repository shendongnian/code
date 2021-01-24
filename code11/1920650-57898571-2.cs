var today = DateTime.Now;
var ticksPerFiveSeconds = TimeSpan.FromSeconds(5).Ticks; 
//DateTime.Now.AddSeconds(5).Ticks - DateTime.Now.Ticks; will aslo return the same value
var twentyYearsFromNow = today.AddYears(20);
var todayTicks = today.Ticks;
var twentyYearsFromNowTicks = twentyYearsFromNow.Ticks;
var listofdate = new List<DateTime>();
var timer = new Stopwatch();
timer.Start();
while (todayTicks <= twentyYearsFromNowTicks)
{
    listofdate.Add(new DateTime(todayTicks));
    todayTicks = todayTicks + ticksPerFiveSeconds;
}
timer.Stop();
Console.WriteLine("ticks :" + timer.ElapsedMilliseconds);
Console.Read();
