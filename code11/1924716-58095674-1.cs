      public ActionResult Create(int? Patient_id)
      {
      CreateBillViewModel model = new CreateBillViewModel();
      if (Patient_id != null)
      {
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
