    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Calendar> GetDatesForArrayOfArtists(string sessionHash, 
                              DateTime start, 
                              DateTime end, 
                              string[] artists)
        {
            var u = UserObject.GetCurrentUser(sessionHash);
            return CalendarObject.GetDates(u.ClientId, 
                       start, 
                       end, 
                       artists.Select(artist => Integer.Parse(artist)).ToArray());
        }
