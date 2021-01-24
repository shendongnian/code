    public async Task<ICollection<SchoolCountVm>> GetSchoolCountBySchoolSystemId(Guid schoolSystemId)
    {
    	 var schoolCountVm = await _GpsContext.School.AsNoTracking()
    							.Where(x => x.SchoolSystemsID == schoolSystemId)
    							.Select(s => new SchoolCountVm()
    										{
    											Count = s.Count()
    										})
    							.ToListAsync();
    	  
    	 return schoolCountVm;
    }
