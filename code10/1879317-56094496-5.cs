|----------------------------------------------|----------------|
| VehicleId    |  ManufactId  |    BrandId     | BrandName      |
|----------------------------------------------|----------------|
|  1           |    null      |      1         | Toyota         |
|----------------------------------------------|----------------|
|  2           |    1         |      1         | Camry          |
|----------------------------------------------|----------------|
|  3           |    2         |      1         | Camry/Vista    |
|----------------------------------------------|----------------|
|  4           |    2         |      1         | Camry/Scepter  |
As you can see, the model Camry is the relationship between the versions and the company.
When VehicleId is 2 (from Camry) you look for records where ManufactId is 2 (Vista and Scepter).
For Nissan instead:
|----------------------------------------------|----------------|
| VehicleId    |  ManufactId  |    BrandId     | BrandName      |
|----------------------------------------------|----------------|
|  9           |    null      |      9         | Nissan         |
|----------------------------------------------|----------------|
|  10          |    9         |      9         | Datsun         |
|----------------------------------------------|----------------|
|  11          |    9         |      9         | Datsun 13T     |
Datsun doesn't have childs (no record have ManufactId equal to 10). Update Datsun 13 T record to ManufactId 10 to see it.
The same goes for the rest.
Moreover, because you hydrate the objects of the list inside the innermost foreach loop (and you never reach that code) you don't even get the empty objects.
If the data is wrong and you can't do anything about it, one possible way to handle these cases is to generate objects with the available info:
....
List<VehicleListModel> vehicleList = new List<VehicleListModel>();
var companies = _context.Where(x => x.ManufactId == null).ToList();
foreach (var company in companies)
{
    var models = _context.Where(y => company.VehicleId == y.ManufactId).ToList();
    if (models.Any())
    {
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
    else
    {
        VehicleListModel vehList = new VehicleListModel();
        vehList.CompanyId = company.VehicleId;
        vehList.CompanyName = company.BrandName;
        vehList.ParentVehicleId = 0;
        vehList.ParentVehicleName = "N/A";
        vehList.ChildVehicleId = 0;
        vehList.ChildVehicleName = "N/A";
        vehicleList.Add(vehList);
    }
}
....
Also, as @Yair suggested, you need to change Crown to ManufactId = 1 
