var groupByRegionBucket = lsttest
                          .GroupBy(x => new { x.Region, x.Bucket, x.AgreementId })
                          .Select(y => new TestOutput
                          {
                              Region = y.Key.Region,
                              Bucket = y.Key.Bucket,
                              Attempt1 = y.Count() == 1 ? 1 : 0,
                              Attempt2 = y.Count() == 2 ? 2 : 0,
                              Attempt3 = y.Count() == 3 ? 3 : 0,
                              AttemptMoreThan3 = y.Count() > 3 ? y.Count() : 0,
                          })
                          .ToList()
                          .GroupBy(z => new { z.Region })
                          .Select(z1 => new TestOutput
                          {
                              Region = z1.Key.Region,
                              Bucket = z1.Sum(a => a.Bucket),
                              Attempt1 = z1.Sum(a => a.Attempt1),
                              Attempt2 = z1.Sum(a => a.Attempt2),
                              Attempt3 = z1.Sum(a => a.Attempt3),
                              AttemptMoreThan3 = z1.Sum(a => a.AttemptMoreThan3),
                          }).ToList();
