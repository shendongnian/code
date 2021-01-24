    public class SecurityRepository : ISecurityRepository
    {
        public SecurityRepository(IAppStateAccessor accessor)
        {
            _userId = accessor.AppState.userId;
            _sessionId = accessor.AppState.sessionId;
        }
        // some other methods
    }
