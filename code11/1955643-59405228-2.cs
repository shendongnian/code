public ActionResult Create()
{
   AspNetUser aspNetUser = new AspNetUser();
   ConfigureViewModel(aspNetUser.ToString());
   List<Services> servicelist = db.Services.ToList();
   ViewBag.servicelist = new SelectList(servicelist, "Id","Name");
   
   return View();
}
But in your view, you should use model.service.Id and not Name.
@Html.DropDownListFor(model => model.service.Id, new SelectList(" "), "--Select Service--", new { @class = "form-control", @id = "dropdownServices" })
Then in your controller, retain this;
newAppointments = new Appointments()
{
   AspNetUser = appointments.AspNetUser,
   service = appointments.service,
};
