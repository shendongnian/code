    var list = registrations.Select(r => new WorkListItem
               {
                   Id = r.Id,
                   ClientAccountId = r.AccountNumber,
                   DateAdded = r.DateAdded,
                   DateUpdated = r.DateUpdated,
                   Patient = r.Patient,
                   InsuraceInfos = r.Patient.InsuranceInfos
               }).ToList();
