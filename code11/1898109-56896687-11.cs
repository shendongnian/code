    public class SecurityRepository : ISecurityRepository
    {
        public SecurityRepository(AppStateAccessor accessor)
        {
            _userId = accessor.AppState.userId;
            _sessionId = accessor.AppState.sessionId;
        }
        // some other methods
    }
