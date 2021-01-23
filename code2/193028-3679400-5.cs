        [StructLayout(LayoutKind.Explicit)]
        private struct Test
        {
            [FieldOffset(0)]
            public double _d1;
            [FieldOffset(4)]
            public double _d2;
        }
        private static Test _test;
        [STAThread]
        static void Main()
        {
            new Thread(KeepMutating).Start();
            KeepReading();
        }
        private static void KeepReading()
        {
            while (true)
            {
                double dummy = _test._d1;
                double dCopy = _test._d2;
                // In release: if (...) throw ...
                Debug.Assert(dCopy == 0D || dCopy == double.MaxValue); // Never fails
            }
        }
        private static void KeepMutating()
        {
            Random rand = new Random();
            while (true)
            {
                _test._d2 = rand.Next(2) == 0 ? 0D : double.MaxValue;
            }
        }
