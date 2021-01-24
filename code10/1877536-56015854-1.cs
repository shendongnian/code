    var keywords = new List<Keyword>();
     var identityUser = await UserManager.GetUserAsync(User);
                  foreach (var keywordString in keywordsThatNeedToBeSaved)
                  {
                    keywords.Add(new Keyword()
                    {
                      UserId = identityUser.Id,
                      Value = keywordString
                    });
                  }
                  ScrubberDbContext.Keywords.AddRange(keywords);
                    await ScrubberDbContext.SaveChangesAsync();
