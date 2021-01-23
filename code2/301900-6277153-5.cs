     var salesusers = (
                        from s in l
                            select new
                            {
                                Username = s.Username.Split('.')[1].ToTitleCase() + " " + s.Username.Split('.')[0].ToTitleCase(),
                                Surname = s.Username.Split('.')[1].ToTitleCase(),
                                Forename = s.Username.Split('.')[0].ToTitleCase(),
                                UserId = s.SalesUserId
                            }
                     ).OrderBy(a => a.Surname).ThenBy(a => a.Forename);
