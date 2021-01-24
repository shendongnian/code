    public class entry
    {
        public int Odometer_km;
        public DateTime epochasdate;
        public int Tanktemperature_C;
        public int Pressure_bar;
    }
    class Program
    { 
        static void Main(string[] args)
        {
            List<entry> entries = new List<entry>(){
                new entry() {epochasdate = new DateTime(2019, 07, 29, 7, 2, 1), Odometer_km = 10, Pressure_bar = 1, Tanktemperature_C = 23},
                new entry() { epochasdate = new DateTime(2019, 07, 29, 7, 1, 1), Odometer_km = 20, Pressure_bar = 2, Tanktemperature_C = 25 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 7, 3, 1), Odometer_km = 22, Pressure_bar = 2, Tanktemperature_C = 24 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 7, 22, 1), Odometer_km = 25, Pressure_bar = 4, Tanktemperature_C = 22 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 8, 24, 1), Odometer_km = 36, Pressure_bar = 2, Tanktemperature_C = 20 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 8, 21, 1), Odometer_km = 42, Pressure_bar = 3, Tanktemperature_C = 19 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 8, 29, 1), Odometer_km = 50, Pressure_bar = 2, Tanktemperature_C = 21 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 8, 22, 1), Odometer_km = 55, Pressure_bar = 4, Tanktemperature_C = 20 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 8, 52, 1), Odometer_km = 62, Pressure_bar = 2, Tanktemperature_C = 19 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 9, 43, 1), Odometer_km = 80, Pressure_bar = 3, Tanktemperature_C = 17 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 9, 22, 1), Odometer_km = 120, Pressure_bar = 1, Tanktemperature_C = 18 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 9, 12, 1), Odometer_km = 140, Pressure_bar = 3, Tanktemperature_C = 16 },
                new entry() { epochasdate = new DateTime(2019, 07, 29, 9, 31, 1), Odometer_km = 156, Pressure_bar = 2, Tanktemperature_C = 17 }
            }; 
            var groupedbyhour = entries.GroupBy(entry => entry.epochasdate.Date.AddHours(entry.epochasdate.Hour))//group by hour
                                       .Select(HourGroup => new
                                       {
                                           TankTemp = HourGroup.Average(x => x.Tanktemperature_C),
                                           Bar = HourGroup.Average(x => x.Pressure_bar),
                                           MinOdo = HourGroup.Min(x => x.Odometer_km),
                                           MaxOdo = HourGroup.Max(x => x.Odometer_km),
                                           MeasureTime = HourGroup.Max(x => x.epochasdate.Date.AddHours(x.epochasdate.Hour))
                                       }).ToList();
        }
    }
