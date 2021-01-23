    var configs = db.RoomConfigurations
                    .Select( r => new RoomConfiguration
                     {
                         ConfigID = r.ConfigID,
                         ConfigName = r.ConfigName,
                         ...
                         Lines = db.LineConfigs
                                   .Where( l => l.RoomConfigID == r.ConfigID )
                                   .ToList()
                     });
