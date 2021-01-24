    // GroupJoin Personnel with PersonnelDrivingLicenses
    var personnelWithTheirDrivingLicenses = myDbContext.Personnel
        .GroupJoin(myDbDcontext.PersonnelDrivingLicenses,
        // from every personnel object take the Id,
        personnel => personnel.Id,
        // from every driving license take the PersonnelId
        personnelDrivingLicence => personnelDrivingLicence.PersonnelId,
        // Take the Personnel, with all his matching driving licenses to make a new:
        (personnel, drivingLicenses) => new
        {
            // for optimal efficiency, Select only the properties you plan to use:
            Id = personnel.Id,
            Name = personnel.Name,
            ...
            DrivingLicenses = drivingLicenses
                .Where(drivingLicense => ...) // only if you don't want all his DrivingLicenses
                .Select(drivingLicense => new
                {
                    // again, select only the properties you plan to use:
                    Id = drivingLicense.Id,
                    Type = drivingLicense.Type,
                    ...
                    // not needed, you already know the value:
                    // PersonnelId = drivingLicense.PersonnelId,
                })
                .ToList(),
        });
