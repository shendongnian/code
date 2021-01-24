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
		public IActionResult CreateTags([FromHeader(Name = "data-type")] string dataType, [FromBody] jsonInput)
		{
            var tagDto = _tagsFactory.CreateTags(dataType, jsonInput);
			
			return Ok(tagDto);
		}
	}
