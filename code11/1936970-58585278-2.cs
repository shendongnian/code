    public PatientController(IUnitOfWorkFactory unitOfWorkFactory, IPatientRepository patientRepository)
    {
        this.UnitOfWorkFactory = unitOfWorkFactory;
        this.PatientRepository = patientRepository;
    }
    
    public IActionResult FamilyDoctor()
    {
        using(var unitOfWork = UnitOfWorkFactory.Create())
        {
            var measurements = PatientRepository.GetAllMeasurements(unitOfWork);
            var viewModels = measurements.Select(x => new MeasurementViewModel
            {
                ID = x.Id,
                BloodSugar = x.BloodSugar,
                BloodSugarDesired = x.BloodSugarDesired,
                Description = x.Description,
                Time = x.Time
            }).ToList();
           
         ViewData["Patient"] = viewModels;
         return View();
    }    
