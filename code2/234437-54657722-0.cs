    licenseLookupItems = tmpList
                    .GroupBy(x => new {x.LicenseNumber, x.Name, x.Location, x.Active, x.Archived})
                    .Select(p => p.FirstOrDefault())
                    .Select(p => new LicenseNumberLookupItem
                    {
                        LicenseNumber = p.LicenseNumber,
                        Name = p.Name,
                        Location = p.Location,
                        Active = p.Active,
                        Archived = p.Archived
                    })
                    .ToList();
