    var allSystemsAndLicenses = (from s in _context.Systems
    	join sl in _context.SoftwareLicenses on s.Id equals sl.SystemId into sll
    	from sl2 in sll.DefaultIfEmpty()
    	join sv in _context.SoftwareVersions on sl2.SoftwareVersionId equals sv.Id into svv
    	from sv2 in svv.DefaultIfEmpty()
    	join fl in _context.FeatureLicenses on sl2.Id equals fl.SoftwareLicenseId into fll
    	from fl2 in fll.DefaultIfEmpty().Where(a => a.IsActive)
    	join sf in _context.SoftwareFeatures on fl2.SoftwareFeatureId equals sf.Id into sff
    	from sf2 in sff.DefaultIfEmpty()
    	select new SystemLicenseResult
    	{
    		LicenseId = sl2.Id,
    		SerialNumber = s.SystemSerial,
    		LicenseVersion = sv2.LicenseVersion + " (" + sv2.Software.Name + ")",
    		LicenseExpiryDate = sl2.CreatedDate,
    		LicenseFeatures = sf2.Name,
    		CreatedDate = sl2.CreatedDate
    	});
    // I have some predicates defined that I am not putting here, but they do exist.
    var filteredResults = allSystemsAndLicenses.Where(predicates);
    var groupedResult = filteredResults.GroupBy(a => a.LicenseId);
    var result = groupedResult.ToList()
        // Because the ToList(), this select projection is not done in the DB
        .Select(eg => new SystemLicenseResult
            {
                LicenseId = eg.Key,
                SerialNumber = eg.First().SerialNumber,
                LicenseFeatures = string.Join(",", eg.Select(i => i.LicenseFeatures))
            })
