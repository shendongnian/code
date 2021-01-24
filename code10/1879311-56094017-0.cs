            foreach (var item in companyInfo)
            {
                var parentInfo = _context.VehicleTable.Where(y => item.VehicleId == y.ManufactId).ToList();
                foreach (var item2 in parentInfo)
                {
                    // This should be removed from the code:
                    // VehicleListModel vehList = new VehicleListModel();
                    var childInfo = _context.VehicleTable.Where(y => item2.VehicleId == y.ManufactId).ToList();
                    foreach (var item3 in childInfo)
                    {
                        // Instead, it's initialized here:
                        VehicleListModel vehList = new VehicleListModel();
                        //if ChildVehicleId does not exist, 0 & N/A are 
                        //returned
                        vehList.CompanyId = item.VehicleId;
                        vehList.CompanyName = item?.BrandName ?? "N/A";
                        vehList.ParentVehicleId = item2?.VehicleId ?? 0;
                        vehList.ParentVehicleName = item2?.BrandName ?? "N/A";
                        vehList.ChildVehicleId = item3?.VehicleId ?? 0;
                        vehList.ChildVehicleName = item3?.BrandName ?? "N/A";
                        vehicleList.Add(vehList);
                    }
                }
            }
