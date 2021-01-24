        ` UUT uutObj = new UUT
                        {
                          Status = "laüft",
                          UutId = "TS220",
                          ClockingCycles = 2000,
                          Offset = 100,
                          StartCycles = 0,
                          Timestamp = DateTime.Now,
                          UUTHistory = null
                        };
            
            var enduranceUpdate = update.Set("Countries.0.Cities.0.EnduranceTest.0.ClockDistributor.0.Channels.0.UUTs.$", uutObj);`
    `var enduranceTestFound = filterVM.And(
                    Builders<ServerTreeVm>.Filter.Where(x => x.Countries.Any(y =>
                        y.Cities.Any(z => z.EnduranceTests.Any(a => a.EnduranceInfo.Any(b => b.Channels.Any(c=>c.Uuts.Any(d=>d.UutId == "TS220"))))))));
        UpdateResult res = collectionEndurance.UpdateOne(enduranceTestFound, enduranceUpdate);`
