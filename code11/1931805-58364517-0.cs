    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
             class Program
        {
            static void Main(string[] args)
            {
                string json = @"{""SoftHoldIDs"": 444,""AppliedUsages"": [    {""SoftHoldID"": 444,""UsageYearID"": 223232,""DaysApplied"": 0,""PointsApplied"": 1}],""Guests"": [ 1, 2]}";
    
                Rootobject reservationDto = JsonConvert.DeserializeObject<Rootobject>(json.ToString());
    
                Debug.WriteLine(reservationDto.SoftHoldIDs);
                foreach (var guest in reservationDto.Guests)
                {
    
                    Debug.WriteLine(guest);
                }
    
            }
        }
    
        public class Rootobject
        {
            public int SoftHoldIDs { get; set; }
            public Appliedusage[] AppliedUsages { get; set; }
            public int[] Guests { get; set; }
        }
    
        public class Appliedusage
        {
            public int SoftHoldID { get; set; }
            public int UsageYearID { get; set; }
            public int DaysApplied { get; set; }
            public int PointsApplied { get; set; }
        }
    
    
    }
