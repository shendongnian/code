public class DeviceIndex : AbstractMultiMapIndexCreationTask<DeviceIndex.Result>
    {
        public class Result
        {
            public string Id { get; set; }
            public string DeviceName { get; set; }
            public bool HasUser { get; set; }
            public int UserCount { get; set; }
        }
        public DeviceIndex()
        {
            AddMap<User>(users => from u in users
                                  from deviceId in u.DeviceIds
                                  let d = LoadDocument<Device>(deviceId)
                                select new Result
                                {
                                    Id = d.Id,
                                    HasUser = true,
                                    UserCount = 1,
                                    DeviceName = d.Name,
                                });
            AddMap<Device>(devices => from d in devices
                                      select new Result
                                      {
                                          Id = d.Id,
                                          HasUser = false,
                                          UserCount = 0,
                                          DeviceName = d.Name,
                                      });
            Reduce = results => from result in results
                                group result by new { result.Id } into g
                                select new Result
                                {
                                    Id = g.First().Id,
                                    DeviceName = g.First().DeviceName,
                                    HasUser = g.Any(e => e.HasUser),
                                    UserCount = g.Sum(e => e.UserCount),
                                };
        }
    }
and you can call it like this
var result = await _session.Query<DeviceIndex.Result, DeviceIndex>().ToListAsync();
