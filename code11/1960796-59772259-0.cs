    public class VideoController : Controller
    {
        private readonly VideoLogic _videoLogic;
        private readonly CategoryLogic _categoryLogic;
        private readonly ReportLogic _reportLogic;
        private readonly CommentLogic _commentLogic;
        private readonly UserLogic _userLogic;
        private readonly IHostingEnvironment _environment;
        public VideoController(VideoLogic videoLogic, CategoryLogic categoryLogic, ReportLogic reportLogic, CommentLogic commentLogic, UserLogic userLogic, IHostingEnvironment environment)
        {
            _videoLogic = videoLogic;
            _categoryLogic = categoryLogic;
            _reportLogic = reportLogic;
            _commentLogic = commentLogic;
            _userLogic = userLogic;
            _environment = environment;
        }
    
