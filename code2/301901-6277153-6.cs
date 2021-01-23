    var salesusers = l.Select(g =>new {
                                Username = g.Username.Split('.')[1].ToTitleCase() + " " + g.Username.Split('.')[0].ToTitleCase(),
                                Surname = g.Username.Split('.')[1].ToTitleCase(),
                                Forename = g.Username.Split('.')[0].ToTitleCase(),
                                UserId = g.SalesUserId
                    }).OrderBy(a => a.Surname).ThenBy(a => a.Forename);
