    public interface ITimer
    {
        void CreateTimer(int _interval, TimerDelegate _delegate);
        void StopTimer();
        // etc...
    } // eo interface ITimer
