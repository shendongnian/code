        class Segments
        {
            public const int None = 0;
            public const int Segm1 = 1;
            public const int Segm2 = 2;
        }
        int currentSegm = 0;
        int segm1counter = 0;
        int segm2counter = 0;
        object segm1lock = new object();
        object segm2lock = new object();
        void SomeOperationA()
        {
            while (
                Interlocked.CompareExchange(ref currentSegm, Segments.Segm1, Segments.Segm1) != Segments.Segm1
                &&
                Interlocked.CompareExchange(ref currentSegm, Segments.Segm1, Segments.None) != Segments.None
                )
            {
                Thread.Yield();
            }
            Interlocked.Increment(ref segm1counter);
            try
            {
                //Segment1: 
                //... only executes if no threads are executing in Segment2 ...                 
            }
            finally
            {
                lock (segm1lock)
                {
                    if (Interlocked.Decrement(ref segm1counter) == 0)
                        currentSegm = Segments.None;
                }
            }
        }
        void SomeOperationB()
        {
            while (
                Interlocked.CompareExchange(ref currentSegm, Segments.Segm2, Segments.Segm2) != Segments.Segm2
                &&
                Interlocked.CompareExchange(ref currentSegm, Segments.Segm2, Segments.None) != Segments.None
                )
            {
                Thread.Yield();
            }
            Interlocked.Increment(ref segm2counter);
            try
            {
                //Segment2: 
                //... only executes if no threads are executing in Segment2 ...                 
            }
            finally
            {
                lock (segm2lock)
                {
                    if (Interlocked.Decrement(ref segm2counter) == 0)
                        currentSegm = Segments.None;
                }
            }
        }
