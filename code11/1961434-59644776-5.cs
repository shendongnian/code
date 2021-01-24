    var reservation = JsonConvert.DeserializeObject<RootObject>(str);
    var flattenedReservation = new[]{reservation}.SelectMany(x=>x.DomesticFlightInfos
                                  .GroupBy(v=>v.IsInbound)
                                  .Select(c =>
                                            {
                                               x.DomesticFlightInfos = c.ToList(); 
                                               return x;
                                             }));
    var jsonCollection = flattenedReservation.Select(x=> JsonConvert.SerializeObject(x,settings));
