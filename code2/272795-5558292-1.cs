    var configs = db.RoomConfigurations
                    .Join( db.LineConfigs, r => r.ConfigID, l => l.RoomConfigID, (r,l) => new { RoomConfig = r, LineConfigs = l } )
                    .GroupBy( j => j.RoomConfig )
                    .Select( g => new RoomConfiguration
                     {
                         ConfigID = g.Key.ConfigID,
                         ConfigName = g.Key.ConfigName,
                         ...
                         Lines = g.LineConfigs.ToList()
                     });
                     
