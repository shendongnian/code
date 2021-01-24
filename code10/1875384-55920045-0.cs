    var a = (from h in db.HouseListingEntity
             join p in db.PopulationRegistrationEntity on h.CensusHouseNoID equals p.CensusHouseNoID
             let temp = new { HouseListingEntity = h, PopulationRegistrationEntity = p }
             group temp by temp.HouseListingEntity.State into g
             select new { State = g.Key, Count = g.Count(p1 => p1.PopulationRegistrationEntity.NPRID > 0) });
