    class DependencySpy : IDependency {
        public int ResetCallCount { get; private set; }
        public void Reset() { ResetCallCount++; }
        public void ClearResetCallCount() { ResetCallCount = 0; }
    }
