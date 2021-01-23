     public ActionResult RegistrationTracking(EncryptedId sourceId)
        {
            var registration = learnerRegistrationService.Get(sourceId);                    
            return VerifySanctions(registration.Qualification, View());
        }
        private ActionResult VerifySanctions(Sanction sanction, ViewResult view)
        {
            bool hasSanctions = this.qualificationSanctionsService.HasSanctions(sanction);
            if (hasSanctions)
            {
                return RedirectToAction("Index", "Home");
            }
            return view;
        }
