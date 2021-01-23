        public static IObservable<byte[]> AsyncRead(this NetworkStream stream, int bufferSize)
        {
            return Observable.Defer(() =>
                                        {
                                            try
                                            {
                                                return stream.DataAvailable ? AsyncReadChunk(stream, bufferSize) : Observable.Return(new byte[0], Scheduler.CurrentThread);
                                            }
                                            catch (Exception)
                                            {
                                                return Observable.Return(new byte[0], Scheduler.CurrentThread);
                                            }
                                        })
                .Repeat()
                .TakeWhile((dataChunk, index) => dataChunk.Length > 0);
        }
