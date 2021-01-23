     public static class Session
     {
         public static CAirportData[] _AirportData;
         static Session()
         {
             string airports = possibleAirports.Split(",");
             foreach (string airport in airports)
             {
                 string[] rwys = inif.Read(airport, "rwys").Split(':'); //size is known (2)
                 _AirportData = new CAirportData[] { new CAirportData() { icao=airport, depRwy=rwys[0], arrRwy=rwys[1] } };
             }
         }
     }
