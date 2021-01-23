    public class DataCollectionManagerState
    {
        public static readonly DataCollectionManagerState Off = new DataCollectionManagerState() { };
        public static readonly DataCollectionManagerState Starting = new DataCollectionManagerState() { };
        public static readonly DataCollectionManagerState On = new DataCollectionManagerState() { };
        private DataCollectionManagerState() { }
        public override string ToString()
        {
            if (this == Off) return "Off";
            if (this == Starting) return "Starting";
            if (this == On) return "On";
            throw new Exception();
        }
    }
    public class DataCollectionManager
    {
        private static DataCollectionManagerState _state = DataCollectionManagerState.Off;
        public static void StartDataCollectionManager()
        {
            var originalValue = Interlocked.CompareExchange(ref _state, DataCollectionManagerState.Starting, DataCollectionManagerState.Off);
            if (originalValue != DataCollectionManagerState.Off)
            {
                throw new InvalidOperationException(string.Format("StartDataCollectionManager can be called when it's state is Off only. Current state is \"{0}\".", originalValue.ToString()));
            }
            // Start Data Collection Manager ...
            originalValue = Interlocked.CompareExchange(ref _state, DataCollectionManagerState.On, DataCollectionManagerState.Starting);
            if (originalValue != DataCollectionManagerState.Starting)
            {
                // Your code is really messy
                throw new Exception(string.Format("Unexpected error occurred. Current state is \"{0}\".", originalValue.ToString()));
            }
        }
    }
