    var dailyUpdates = await _context.CoStatusUpdates
                .Include(x => x.CoStatus)
                .Include(x => x.Company)
                   .ThenInclude(x => x.Organisation)
                .ToListAsync();
    
    var result = dailyUpdates.GroupBy(p => p.CompanyId)
                    .Select(x => new CoStatusUpdate
                    {
                        CompanyId = x.Key,
                        Company = new Company() //building new object for the only fields we need otherwise there's way more returned than needed
                        {
                            Organisation = new Organisation()
                            {
                                Name = x.FirstOrDefault(y => y.SubmittedDateTime == x.Max(z => z.SubmittedDateTime)).Company.Organisation.Name,
                                IsDeleted = x.FirstOrDefault(y => y.SubmittedDateTime == x.Max(z => z.SubmittedDateTime)).Company.Organisation.IsDeleted,
                                OrganisationTypeId = x.FirstOrDefault(y => y.SubmittedDateTime == x.Max(z => z.SubmittedDateTime)).Company.Organisation.OrganisationTypeId,
                            }
                        },
                        CoStatusUpdateId = x.FirstOrDefault(y => y.SubmittedDateTime == x.Max(z => z.SubmittedDateTime)).CoStatusUpdateId,
                        CoStatusId = x.FirstOrDefault(y => y.SubmittedDateTime == x.Max(z => z.SubmittedDateTime)).CoStatusId,
                        CoStatus = x.FirstOrDefault(y => y.SubmittedDateTime == x.Max(z => z.SubmittedDateTime)).CoStatus,
                        SubmittedDateTime = x.Max(z => z.SubmittedDateTime)
                    }).Where(x => !x.Company.Organisation.IsDeleted
                         && x.Company.Organisation.OrganisationTypeId == organisationTypeId))
                .ToDictionary(x => x.CompanyId);
