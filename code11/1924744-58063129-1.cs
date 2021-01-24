c#    
    List<Aircraft> aircraftList = new List<Aircraft>();
        using (MemoryStream stream = new MemoryStream(content))
        {
                using (CsvReader csvReader = new CsvReader(new StreamReader(stream), true))
                {
                    var records = csvReader.GetRecords<AircraftDTO>();
    
                    foreach (var item in records )
                    {
                        Aircraft aircraft = new Aircraft();
    
                        aircraft.BusinessName = item.BusinessName;
                        aircraft.IssuingCountry = item.IssuingCountry;
                        aircraft.CertificateCode = item.CertificateCode;
                        aircraft.CertificateHolderName = item.CertificateHolderName;
                        aircraft.Tailnumber = item.Tailnumber;
                        aircraft.SerialNumber = item.SerialNumber;
                        aircraft.YearMade = !string.IsNullOrWhiteSpace(item.YearMade) && item.YearMade != "NULL" ? Convert.ToInt32(item.YearMade) : (int?)null;
                        aircraft.Manufacturer = item.Manufacturer
    
                        aircraftList.Add(wyvernAircraft);
                    }
                }
        }
        dbContext.BulkInsert(aircraftList);
