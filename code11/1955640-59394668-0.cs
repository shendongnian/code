[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create(Appointments appointments)
{
   if (ModelState.IsValid)
   {
      appointments = new Appointments()
      {
         AspNetUser = appointments.AspNetUser,
         // accesss use the service Id instead of passing the whole object
         service_Id = appointments.service.Id,
      };
      db.Appointments.Add(appointments);
      db.SaveChanges();
   }
   return RedirectToAction("Index");
}
