    public abstract class BaseController : ControllerBase
    {
        public Task<int> LoggedInUserId()
        {
            return await GetLoggedInUserId();
        }
    }
