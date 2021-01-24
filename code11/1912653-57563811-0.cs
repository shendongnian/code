    public class NationalParkListData
    {
        public string Id { get; set; }
        public Guid StateId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    
        // Depending on how rest-compliant your approach is, you 
        // might include non-collection nested objects or not
        public StateListData State { get; set; }
        public int NationalParkLinksCount { get; set; }
    }
    
    [HttpGet("/states/{stateId:guid}/national-parks")]
    public async Task<IActionResult> GetNationalParksForState(Guid stateId, CancellationToken cancellationToken)
    {
        var stateNationalParks = await _context.NationalParkList
                                       .Where(n => n.StateId == stateId)
                                       .ToListAsync(cancellationToken);
        IEnumerable<NationalParkListData> result = // your mapper logic
        return this.Ok(result);
    }
