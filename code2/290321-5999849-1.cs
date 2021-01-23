    public static IObservable<System.IO.Stream> GetToplevelStreams(IObservable<byte> byteStream)
    {
        return Observable.Create((IObserver<System.IO.Stream> o) =>
        {
            int? size1=null;
            int? size=null;
            var buf = new MemoryStream();
            var subscription = byteStream.Subscribe(v =>
            {
                if (!size1.HasValue)
                {
                    size1 = ((int)v) << 8;
                }
                else if (!size.HasValue)
                {
                    size = size1.Value + v;
                }
                else
                {
                    buf.WriteByte(v);
                }
                if (size.HasValue && buf.Length == size)
                {
                    buf.Position = 0;
                    o.OnNext(buf);
                    buf.SetLength(0);
                    size1 = null;
                    size = null;
                }
            }, (ex)=>o.OnError(ex), ()=>o.OnCompleted());
            return () => subscription.Dispose();
        });
    }
