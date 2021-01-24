                DateTime startDateTime = Convert.ToDateTime(startDate);
                DateTime endDateTime = Convert.ToDateTime(endDate);
                //calculate Ordinary vacation
                var countOrdinaryVacation = (from trans in db.Transactions
                                  where trans.StatusId == 3 &&
                        (trans.EntryDate >= startDateTime && trans.EntryDate <= endDateTime)
                                  group trans by trans.EmpId into empg
                                  select new
                                  {
                                      key = empg.Key,
                                      
                                      OrdinaryVaction = empg.Count()
                                  }).AsQueryable()  ;
                //calculate Casual Vacation 
                var countCasualVacation = (from trans in db.Transactions
                                             where trans.StatusId == 4 &&
                                   (trans.EntryDate >= startDateTime && trans.EntryDate <= endDateTime)
                                             group trans by trans.EmpId into empg
                                             select new
                                             {
                                                 key = empg.Key,
                                                 CasualVacation = empg.Count()
                                             }).AsQueryable();
