    var salesusers =    (
                            from s in lstReport 
                            group s by new { s.SalesUserId,s.Username} 
                            into g
                            select new
                                {
                                    Username = g.Key.Username.Split('.')[1].ToTitleCase() + " " + g.Key.Username.Split('.')[0].ToTitleCase(),  
                                    Surname = g.Key.Username.Split('.')[1].ToTitleCase(),  
                                    Forename = g.Key.Username.Split('.')[0].ToTitleCase(),  
                                    UserId = g.Key.SalesUserId 
                                 }  
                         ).OrderBy(a=> a.Surname).ThenBy(a=> a.Forename);
