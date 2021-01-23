        var listOfMeasurmentTypes = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.GetTypes())
                            .Where(p => typeof(IMeasurementUnitType).IsAssignableFrom(p) 
                                        && !p.IsInterface)
                            .ToList();
