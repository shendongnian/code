    public PatientController(IPatientRepository patientRepository)
    {
        this.PatientRepository = patientRepository;
    }
    
    public IActionResult FamilyDoctor()
    {
         ViewData["Patient"] = PatientRepository.GetAllPatients();
         return View();
    } 
   
