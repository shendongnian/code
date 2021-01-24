    var fromDate = new DateTime(2019,1,1);
    var untilDate = new DateTime(2019,1,2);
    var supervisorsAndSubordinates = employees
                             .Where(e => 
                                      // Supervisor filter
                                      (
                                           e.CreatedOn >= fromDate 
                                        && e.CreatedOn < untilDate
                                      )
                                      ||
                                      // Subordinate filter
                                      (
                                           e.SupervisorID != null
                                        && e.Supervisor.CreatedOn >= fromDate 
                                        && e.Supervisor.CreatedOn < untilDate
                                      ))
                             .ToList();
