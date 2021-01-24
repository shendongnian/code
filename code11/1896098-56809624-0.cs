    var step1 = dataDump.Where(s => 
            s.Code.Any(a => !context.Plants.Select(x => x.Code).Contains(s.Code))
            &&
            s.Code.Any(a => !context.Plants.any(x => x.PlantTypes.Select(t => t.Code).Contains(s.Code)))
                                    
                            ).Select(s => s.Code).Distinct().ToList();
