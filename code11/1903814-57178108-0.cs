    var resultsLeft = revisionsByDate.Select(r => new
                                                  {
                                                      Revision = r,
                                                      Action = progressUpdates.Where(pu => pu.DateCreated <= r.DateCreated)
                                                              .OrderByDescending(pu => pu.DateCreated)
                                                                              .First()
                                                  })
                                     .Select(_ => new
                                                 {
                                                     _.Revision.DateCreated,
                                                     _.Action.Progress,
                                                     _.Revision.RevisionCount
                                                 })
                                     .ToList();
    
    var resultsRight = progressUpdates.GroupJoin(revisionsByDate,
                                                 pu => pu.DateCreated,
                                                 r => r.DateCreated,
                                                (pu, rr) => new                                                                    
                                                            {                                                                        
                                                               ProgressUpdate = pu,                                                                          
                                                               NoMatch =  !rr.Any()                                                                            
                                                            })
                                      .Where(pu => pu.NoMatch)
                                      .Select(pu => new
                                                    {
                                                        pu.ProgressUpdate.DateCreated,
                                                        pu.ProgressUpdate.Progress,
                                                        RevisionCount = 0
                                                    })
                                      .ToList();
    
    
    var results = resultsLeft.Concat(resultsRight)
                             .OrderBy(r => r.DateCreated)
                             .ToList();
