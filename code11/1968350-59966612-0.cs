    var name = _db.tblGames
                  .Where(x => x.GameID == 1)
                  .Select(x => new YourClassName 
                                      {
                                        Title = x.Title,
                                        Column2 = x.Column2,
                                        Column3 = x.Column3
                                      })
                  .SingleOrDefault();
