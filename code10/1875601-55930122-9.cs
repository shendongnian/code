    [Route("api")]
    public class TagsController : Controller
	{
		private readonly ITagsFactory _tagsFactory;
		public TagsController(ITagsFactory tagsFactory)
		{
			_tagsFactory= tagsFactory;
		}
		[HttpPost]
		[Route("tags")]
		public IActionResult CreateTags([FromHeader(Name = "data-type")] string dataType, [FromBody] string jsonInput)
		{
            var tags = _tagsFactory.CreateTags(dataType, jsonInput);
			
			return new ObjectResult(tags)
            {
                StatusCode = 200
            };
		}
	}
