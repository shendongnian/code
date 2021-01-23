    (From l In DataBaseView Select new SomeViewModel
                                    {
                                        Date = l.Date,
                                        Details = l.Details,
                                        Level = l.LevelName,
                                        Id = l.ViewID,
                                        Message = l.Message,
                                        ProjectName = l.projectName,
                                        StatusId = l.StatusID,
                                        StatusName = l.StatusName
                                    }).Skip(50).Take(25)
