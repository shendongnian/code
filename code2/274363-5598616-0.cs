            public static List<VehicleMake> GetInRange(this List<VehicleMake> vehicleList, char RangeStart, char RangeEnd)
            {
                var vehiclesInRange = from vm in vehicleList
                                      where vm.Name[0] >= RangeStart && vm.Name[0] <= RangeEnd
                                      select vm;
                return vehiclesInRange.ToList();
            }
