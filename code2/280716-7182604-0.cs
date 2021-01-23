    public interface IPauseToken 
    {
        bool IsPausedRequested { get; }
        void WaitUntillPaused();
    }
