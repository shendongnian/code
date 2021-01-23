    private ActionResult WhenNoSanctions()
    {
            if(!this.organisationAchievableService.IsAccessibleAchievableVersion(registration.Qualification.Id, this.GetOrganisationId()))
            {
                return new PopupFormResult().Notify(MUI.PleaseSelectACentre);
            }
    
            SetEnrolmentViewData(registration.Enrolment);
    
            ViewData["registrationId"] = sourceId;
            var isComposite = registration.Enrolment.IsComposite();
            ViewData["isComposite"] = isComposite;
    
            this.SetSelectedUnitsViewData(registration, isComposite);
    
            this.SetSelectedQualificationUnitsViewData(isComposite, registration);
    
            return this.PartialView("ModifyUnits", new List<UnitDisplay>());
    }
