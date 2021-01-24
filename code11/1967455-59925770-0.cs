    public async Task<IActionResult> Index(int applicantType) {
        IQueryable<Applicant> cSSDDashboardContext = null;
    
        if (applicantType == 2) {
            cSSDDashboardContext = _context.Applicant
                .Include(a => (a as LegalApplicant).ApplicantId)
                .Include(a => (a as LegalApplicant).ApplicantType)
                .Include(a => (a as LegalApplicant).Address)
                .Include(a => (a as LegalApplicant).Description)
                .Include(a => (a as LegalApplicant).Name)
                .Include(a => (a as LegalApplicant).EconomicCode)
                .Where(a => a.IsDeleted == 0 && a.ApplicantId == (a as LegalApplicant).ApplicantId);
    
        } else if (applicantType == 1) {
            cSSDDashboardContext = _context.Applicant
                .Include(a => (a as PersonApplicant).ApplicantId)
                .Include(a => (a as PersonApplicant).ApplicantType)
                .Include(a => (a as PersonApplicant).Address)
                .Where(a => a.IsDeleted == 0 && a.ApplicantId == (a as PersonApplicant).ApplicantId);
        }
    
        return View(await cSSDDashboardContext.ToListAsync());
    }
