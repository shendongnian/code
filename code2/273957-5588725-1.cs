    public ActionResult GetAll()
    {
        return Json(ppEFContext.Orders
                               .Include(o => o.Patient)
                               .Include(o => o.Patient.PatientAddress)
                               .Include(o => o.CertificationPeriod)
                               .Include(o => o.Agency)
                               .Include(o => o.Agency.Address)
                               .Include(o => o.PrimaryDiagnosis)
                               .Include(o => o.ApprovalStatus)
                               .Include(o => o.Approver)
                               .Include(o => o.Submitter),
            JsonRequestBehavior.AllowGet);
    }
