    public RedirectToRouteResult Delete(int id)
    {
        MyEntities entities = new MyEntities();
        var vendor = entities.Vendors.FirstOrDefault(v => v.VendorID == id);
        foreach (var item in vendor.VendorPriceBreaks.ToList())
            entities.VendorPriceBreaks.Context.DeleteObject(item);
        entities.Vendors.Context.DeleteObject(vendor);
        entities.Vendors.Context.SaveChanges();
        return RedirectToAction("Index");
    }
