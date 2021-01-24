    [ApiController]
    [RoutePrefix("api/[controller]")]
    public class YoutubeController : ControllerBase, IYoutubeController
    {
        [HttpPost, Route("GetVideoAsync")]
        public async Task<YoutubeVideoInfo> GetVideoAsync(string videoId)
        {
            // my code
        }
    
        [HttpGet, Route("Playlist")]
        public List<YoutubeItem> Playlist([FromQuery]string playlistId)
        {
            // My code
        }
    
        [HttpGet, Route("Search/{searchString}/{pageSize}/{relatedTo}/{videoSearchType}")]
        public YoutubeVideoCollection Search(string searchString, int pageSize = 50, string relatedTo = null, VideoSearchType videoSearchType = VideoSearchType.Videos)
        {
         // my code
        }
    }
