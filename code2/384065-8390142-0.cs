    public virtual ActionResult VehicleView(int id, string detailDisplayType)
    {
        var vehicle = VehicleService.Get(id);
        return View("VehicleView", new VehicleViewModel { VehicleDetail = vehicle != null ? vehicle.Details : null, Vehicle = vehicle, DetailDisplayType = detailDisplayType??"features" });
    }
