    [HttpGet]
    public IActionResult Get([FromQuery]SearchQuery queryParam)
    {
      // here you can use queryParam.query
    } 
    
    public class SearchQuery
    {
        [FromQuery(Name = "query")]
        public string query { get; set; }
    
    }
