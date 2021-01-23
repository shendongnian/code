    var qryGeoApppendCount =
                  (from a in append
                  join g in geo
                  on a.Field<string>("RNO")
                  equals g.Field<string>("RNO")
                  group g by g.Field<int>("DSCID") into appendGeo
                  select new
                  {
                    DscId = appendGeo.Key,
                    DscIdCount = appendGeo.Count()
                  })
                  .Where(a => a.DscIdCount > 1);
