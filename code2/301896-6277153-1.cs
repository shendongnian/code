    var salesusers = (l.GroupBy(s => new { SalesUserId = s.SalesUserId, Username = s.Username }).Select(g =>new {
                                    Username = g.Key.Username.Split('.')[1].ToTitleCase() + " " + g.Key.Username.Split('.')[0].ToTitleCase(),
                                    Surname = g.Key.Username.Split('.')[1].ToTitleCase(),
                                    Forename = g.Key.Username.Split('.')[0].ToTitleCase(),
                                    UserId = g.Key.SalesUserId
                        })).OrderBy(a => a.Surname).ThenBy(a => a.Forename);
