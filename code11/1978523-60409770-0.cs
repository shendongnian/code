    var groupByRegionBucketForAttempts = lsttest
                                      .Where(w => !string.IsNullOrEmpty(w.DispositionCode))
                                      .GroupBy(x => new { x.Region, x.Bucket, x.AgreementId })
                                      .Select(y => new
                                      {
                                          Region = y.Key.Region,
                                          Bucket = y.Key.Bucket,
                                          AgreementId = y.Key.AgreementId,
                                          DispositionCode =  y.Count(),
                                          Attempts = 
                                          y.Count() == 1? "Attempt1": 
                                          y.Count() == 2 ? "Attempt2" :
                                          y.Count() == 3 ? "Attempt3" : "Attempt>3"
                                      })
                                      .ToList();
    
                var attemptsQuery = groupByRegionBucketForAttempts
                        .GroupBy(c => new { c.Region, c.Bucket })
                        .Select(g => new {
                            Region = g.Key.Region,
                            Bucket = g.Key.Bucket,
                            Attempt1 = g.Where(x => x.Attempts == "Attempt1").Sum(x => x.DispositionCode),
                            Attempt2 = g.Where(x => x.Attempts == "Attempt2").Sum(x => x.DispositionCode),
                            Attempt3 = g.Where(x => x.Attempts == "Attempt3").Sum(x => x.DispositionCode),
                            AttemptMoreThan3 = g.Where(x => x.Attempts == "Attempt>3").Sum(x => x.DispositionCode)
    
                        }).ToList();
