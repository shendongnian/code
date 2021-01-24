using System;
namespace OnTime
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin  = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minuteArrival = int.Parse(Console.ReadLine());
            string total = ($"{examHour}:{examMin}");
            string totald = ($"{hourArrival}:{minuteArrival}");
            DateTime arrival = new DateTime();
            arrival = DateTime.ParseExact(total, "H:m", null);
            DateTime exam = new DateTime();
            exam = DateTime.ParseExact(totald, "H:m", null);
            TimeSpan span = arrival - exam;
            int hours = span.Hours;
            int minutes = span.Minutes;
            string timediff = hours.ToString("0") + ":" + minutes.ToString("00");
            string minutesdiffOne = minutes.ToString("00");
            if (examHour < hourArrival && (examMin - minuteArrival < 30))
            Console.WriteLine("on time");
            Console.WriteLine($"{minutesdiff:F0}");
        }
    }
}
`
