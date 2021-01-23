        static class Program
        {
            static void Main(string[] args)
            {
                var makes = new List<VehicleMake> { 
                    new VehicleMake { Name = "Acura" },
                    new VehicleMake { Name = "AMG" },
                    new VehicleMake { Name = "Audi" }, 
                    new VehicleMake { Name = "BMW" }, 
                    new VehicleMake { Name = "Chevrolet" },
                    new VehicleMake { Name = "Datsun" },
                    new VehicleMake { Name = "Eagle" }, 
                    new VehicleMake { Name = "Fiat" },
                    new VehicleMake { Name = "Honda" }, 
                    new VehicleMake { Name = "Infiniti" },
                    new VehicleMake { Name = "Jaguar" } 
                }; 
                var atoc =  makes.GetInRange('A', 'C');
                atoc.Print();
                var dtom = makes.GetInRange('D', 'M');
                dtom.Print();
                var mtoz = makes.GetInRange('M', 'Z');
                mtoz.Print();
                Console.ReadLine();
            }
            static List<VehicleMake> GetInRange(this List<VehicleMake> vehicleList, char RangeStart, char RangeEnd)
            {
                var vehiclesInRange = from vm in vehicleList
                                      where vm.Name[0] >= RangeStart && vm.Name[0] <= RangeEnd
                                      select vm;
                return vehiclesInRange.ToList();
            }
            static void Print(this List<VehicleMake> vehicles)
            {
                Console.WriteLine();
                vehicles.ForEach(v => Console.WriteLine(v.Name));
            }
        }
