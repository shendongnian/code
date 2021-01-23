    public class ForumController : Controller
    {
        ...
        [Authorize]
        public ActionResult CreateReply(int topicId)
        {
            ...
        }
        
        ...
    }
