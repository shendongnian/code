    sealed class TestTickStream {
        public readonly int NumTicks;
        readonly DateTime DummyTime = DateTime.MinValue;
        int count = 0;
        public TestTickStream(int numTicks) {
            NumTicks = numTicks;
        }
        public bool MoveNext(ref Tick tick) {
            if (++count > NumTicks) return false;
            tick = new Tick(count, count, count, count, DummyTime);
            return true;
        }
    }
    /// <summary>
    /// A stream that returns <see cref="AllocatedTick"/> ticks for tests involving allocations
    /// </summary>
    sealed class AllocatedTickStream {
        public readonly int NumTicks;
        readonly DateTime DummyTime = DateTime.MinValue;
        int count = 0;
        public AllocatedTickStream(int numTicks) {
            NumTicks = numTicks;
        }
        public AllocatedTick MoveNext() {
            if (++count > NumTicks) return null;
            return new AllocatedTick(count, count, count, count, DummyTime);
        }
    }
