    public async Task<ActionResult> DraftScores()
    {
       ...
       List<Match> result = await GetFixturesAsync();
       ...
    }
     
