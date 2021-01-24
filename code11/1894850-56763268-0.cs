    var ans2 = (from b in dbContext.Buildings
                join f in dbContext.Floors on b.Id equals f.BuildingId into fj
                from f in fj.DefaultIfEmpty()
                join r in dbContext.Rooms on f.Id equals r.FloorId into rj
                from r in rj.DefaultIfEmpty()
                join ro in dbContext.RoomOccupancies on r.Id equals ro.RoomId
                join w in dbContext.WorkGroups on ro.WorkGroupId equals w.Id into wj
                from w in wj.DefaultIfEmpty()
                where !w.IsFinished && w.StartDate < DateTime.Now
                select new BuildingDatableElementDTO() {
                    BuildingId = b.Id,
                    Name = b.Name,
                    FloorCount = fj.Count(),
                    RoomCount = rj.Count(),
                    CurrentWorkerCount = wj.Sum(w => w.NumberOfEmployees)
               })
               .ToList();
