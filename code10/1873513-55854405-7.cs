    public class GetByIdsRequest
    {
        [FromRoute(Name = "day")]
        public int Day { get; set; }
        [BindRequired]
        [FromQuery(Name = "ids")]
        [CommaSeparated]
        public IEnumerable<int> Ids { get; set; }
        [FromQuery(Name = "include")]
        [CommaSeparated]
        public IEnumerable<IncludingOption> Include { get; set; }
        [FromQuery(Name = "order")]
        public string Order { get; set; }
        [BindProperty(Name = "")]
        public NestedModel NestedModel { get; set; }
    }
    public class NestedModel
    {
        [FromQuery(Name = "extra-include")]
        [CommaSeparated]
        public IEnumerable<IncludingOption> ExtraInclude { get; set; }
        [FromQuery(Name = "extra-ids")]
        [CommaSeparated]
        public IEnumerable<long> ExtraIds { get; set; }
    }
    // the controller's action
    public async Task<IActionResult> GetByIds(GetByIdsRequest request)
    {
        // do something
    }
