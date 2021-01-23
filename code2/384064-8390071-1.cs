    routes.MapRoute("VehicleView", "vehicles/{id}/{detailDisplayType}",
        new {
            area = "",
            controller = "vehicles",
            action = "vehicleview",
            detailDisplayType = UrlParameter.Optional 
        }
    );
---
    public virtual ActionResult VehicleView(int id, DetailDisplayType? detailDisplayType)
    {
        var vehicle = VehicleService.Get(id);
        var model = new VehicleViewModel
        {
            VehicleDetail = vehicle == null ? null : vehicle.Details, 
            Vehicle = vehicle,
            DetailDisplayType = detailDisplayType ?? DetailDisplayType.Features
        }
        return View("VehicleView", model);
    }
