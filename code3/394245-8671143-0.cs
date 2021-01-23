    ReadViewModel[] result = ( from read in context.Reads
                               where SomeCondition
                               select new ReadViwModel
                               {
                                   ReadId = read.ReadId,
                                   // . . .
                                   HasAlarms = read.Alarms.Any(),
                                   // . . .
                               } ).ToArray();    
