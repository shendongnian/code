    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateBillViewModel model, int? Patient_id)
    {
    if (ModelState.IsValid)
    {
    //Save into db
    }
    model.PatientAppointmentDate = (from p in db.tblPatientAppointments
    where p.patient_id == Patient_id
    select new SelectListItem
    {
    Text = p.AppointmentDate,
    Value = p.ID.ToString()
    }).ToList();
    }
    return View(model);
    }
