    dbo.Companies.Join(dbo.Persons, 
                       c => c.AccountCoordinatorPersonId,  
                       p => p.PersonId,  
                       (c, p) => new 
                       {  
                           Company = c,  
                           AccountCoordinator = p.FirstName + ' ' + p.Surname  
                       })
                 .Join(dbo.Persons,  
                       c => c.Company.AccountManagerPersonId,  
                       p2 => p2.PersonId,  
                       (c, p2) => new 
                       {  
                           c.Company.CompanyId,  
                           c.Company.CompanyName,  
                           c.AccountCoordinator,  
                           AccountManager = p2.FirstName + ' ' + p2.Surname 
                       });
