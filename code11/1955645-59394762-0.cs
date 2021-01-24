vehicle.RegisteredDate = DateTime.Now(); // watch out, this is the server time
vehicle.RegisteredBy = "admin";
See the full post method below;
// controller code block        
 public ActionResult Create([Bind(Include = "Id,VehicleType,Amount,RenewPeriod,Status,ModifiedBy,ModifiedDate")] Vehicle vehicle)
{
   // assign here
   vehicle.RegisteredDate = DateTime.Now(); // watch out, this is the server time
   vehicle.RegisteredBy = "admin";
   if (ModelState.IsValid)
   {
      db.Vehicle.Add(vehicle);
      db.SaveChanges();
      return RedirectToAction("Index");
   }
   return View(vehicle);
}
----------
For the status Field, on your Create method (NOT POST) you could instantiate the object, assign its values, and pass it to the view;
***Be sure to include the Status field in your View***
public ActionResult Create()
{
   Vehicle newVehicle = new Vehicle();
   newVehicle.Status = "New";
   return View(newVehicle);
}
