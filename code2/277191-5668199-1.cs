    [HttpGet]
    public ActionResult Create()
    {
      var model = new PressViewModel();
      model.PressPaperSpeeds = _SomeRepository.PopulatePaperDataLeavingIDsUntouched();
      // after this line i will have all paper information inside my viewmodel's property that will be passed to view and user will enter corresponding speeds for current press   
    }
