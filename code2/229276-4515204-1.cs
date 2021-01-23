    public class CallController : Controller
        {
            private readonly CallTrackRepository _repository;
    
            public CallController()
            {
                _repository= new CallTrackRepository();
            }
    }
