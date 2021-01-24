|  1           |    null      |      1         | Toyota         |
|----------------------------------------------|----------------|
|  2           |    1         |      1         | Camry          |
|----------------------------------------------|----------------|
|  3           |    2         |      1         | Camry/Vista    |
|----------------------------------------------|----------------|
|  4           |    2         |      1         | Camry/Scepter  |
As you can see, the model Camry is the relationship between the versions and the company.
These versions connect when VehicleId is 2 (from Camry) and ManufactId is 2 (from Vista and Scepter)
For Nissan instead:
|  9           |    null      |      9         | Nissan         |
|----------------------------------------------|----------------|
|  10          |    9         |      9         | Datsun         |
|----------------------------------------------|----------------|
|  11          |    9         |      9         | Datsun 13T     |
The data lacks from that relationship, so the **childInfo** variable is empty. 
It actually gets the VehicleId 10 from the first match where the ManufactId is 9 and then tries to find matches for the childInfo variable where the ManufactId is 10 (there are none). The same for the next one, 11.
Because you hydrate the objects of the list inside the innermost foreach loop (and you never reach that code) you don't even get the empty objects.
One possible way to handle this (I've changed your variables for a better understanding) is:
....
List<VehicleListModel> vehicleList = new List<VehicleListModel>();
    var companies = _context.Where(x => x.ManufactId == null).ToList();
    foreach (var company in companies)
    {
        var models = _context.Where(y => company.VehicleId == y.ManufactId).ToList();
        foreach (var model in models)
        {
            var versions = _context.Where(y => model.VehicleId == y.ManufactId).ToList();
            if (versions.Any())
            {
                foreach (var version in versions)
                {
                    VehicleListModel vehList = new VehicleListModel();
                    vehList.CompanyId = company.VehicleId;
                    vehList.CompanyName = company?.BrandName ?? "N/A";
                    vehList.ParentVehicleId = model?.VehicleId ?? 0;
                    vehList.ParentVehicleName = model?.BrandName ?? "N/A";
                    vehList.ChildVehicleId = version?.VehicleId ?? 0;
                    vehList.ChildVehicleName = version?.BrandName ?? "N/A";
                    vehicleList.Add(vehList);
                 }
             }
             else 
             {
                 VehicleListModel vehList = new VehicleListModel();
                 vehList.CompanyId = company.VehicleId;
                 vehList.CompanyName = company.BrandName;
                 vehList.ParentVehicleId = model.VehicleId;
                 vehList.ParentVehicleName = model.BrandName;
                 vehList.ChildVehicleId = 0;
                 vehList.ChildVehicleName = "N/A";
                 vehicleList.Add(vehList);
             }
         } 
     }
....
Also, as @Yair suggested, you need to change Crown to ManufactId = 1 
