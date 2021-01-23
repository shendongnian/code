    string username = membership.GetUser(cANDu[1]).ProviderUserKey.ToString();
    var query = objDC.tickets
                     .Where(el => el.typeOfGame == cANDu[0] &&
                                  el.username == username);
    if (condition)
    {
        query = query.Where(el => el.results != null);
    }
    var result = query.Select(el => new { el.AllGamesTickets, el.WGamesTickets})
                      .FirstOrDefault();
