    var companies = cprIdentificationReply.Companies
                                        .Where(x => (x.Employee
                                                      .Any(y => (y.IDCardIssued
                                                                  .Any(z => z.CardNumber
                  .Equals(number, StringComparison.InvariantCultureIgnoreCase)
                                                                      )
                                                          )
                                               ).ToList();
