    public async Task<IActionResult> Index()
    {
    	  var ap = await (from p in _context.Mstr_Patients
    			          join e in _context.Appointments on p.PatientID equals e.PatientID
    			          select new AppointmentsViewModel
    								{ 
    									No = e.AppointmentNo, 
    									Date = e.AppointmentDate, 
    									Name = p.FullName, 
    									Ref = e.RefDoctor 
    								}).ToListAsync();
    
    
    	return View(ap);
    }
