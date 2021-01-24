    public class ViewModelBase:Screen
    {
        private SessionInfo _sessionInfo;
        public ViewModelBase(SessionInfo sessionInfo)
        {
            _sessionInfo = sessionInfo;
        }
        public void NotifyGuardMethods()
        {
            NotifyOfPropertyChange(nameof(CanTakeAction));
        }
        public virtual bool CanTakeAction { get; set; } = false;
    }
