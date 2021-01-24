        public ActionResult Create()
        {
            var Clinic = context.Clinic.ToList();
            var model = new Appointments()
            {
               Clinic = Clinic.Select(x => new SelectListItem
               {
                 Value = x.ClinicId.ToString(),
                 Text = x.ClinicName
               }
            }
            return View(model);
        }
