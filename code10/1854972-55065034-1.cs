    public class ProgressObserver : IProgressObserver
    {
        private Action<Int32> _updater = _ => { };
        public void Update(Int32 percent)
        {
            this._updater(percent);
        }
        public void Register(Action<Int32> updater)
        {
            this._updater = updater;
        }
    }
