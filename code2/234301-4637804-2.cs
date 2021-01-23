    var topicsQuery = board.Topics.Select(x => new { 
                                                      Topic = x, 
                                                      LastActivityDate = x.Replies.Any() 
                                                          ? x.Replies.Last().PostedDate 
                                                          : x.PostedDate
                                        })
                                 .OrderByDescending(p => p.LastActivityDate)
                                 .Select(r => r.Topic)
