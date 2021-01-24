                _db1UOW.Begin(); //creating sql transaction
                await _db1UOW.IDenialDetailsRepositorydb1.InsertDenialDetails(denialsDetails);
                await _db1UOW.IRuleDetailsRepositorydb1.InsertRulesDetails(rulesDetails);
                _db2UOW.Begin(); //creating sql transaction 
                await _db2UOW.IRuleDetailsRepository.GetRulesDetails();
                await _db2UOW.IDenialDetailsRepository.InsertDenialDetails(denialsDetails);
                var data = await _db2UOW.IRuleDetailsRepository.InsertRulesDetails(rulesDetails);
 
                _db1UOW.Commit(); //commitng sql transaction
                try
                {
                   _db2UOW.Commit(); //commitng sql transaction
                }
                catch (Exception ex)
                {
                   LogError("Second transaction failed to commit after first one committed.  Administrators may need to fix stuff");
                   throw;
                }
 
