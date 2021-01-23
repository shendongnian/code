    var getHistoryTips = (condition) ? (from el in objDC.tickets
                                         where el.typeOfGame == cANDu[0]
                                         && el.username == Membership.GetUser(cANDu[1]).ProviderUserKey.ToString()
                                         select new { el.AllGamesTickets, el.WGamesTickets}).FirstOrDefault() : 
                                       (from el in objDC.tickets
                                         where el.typeOfGame == cANDu[0]
                                         && el.results != null
                                         && el.username == Membership.GetUser(cANDu[1]).ProviderUserKey.ToString()
                                         select new { el.AllGamesTickets, el.WGamesTickets}).FirstOrDefault();
