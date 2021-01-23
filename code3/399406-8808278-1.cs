    public class DummyStream : MemoryStream
    {
        protected override void Dispose(bool disposing)
        {
            Trace.WriteLine("Do I get disposed?");
            base.Dispose(disposing);
        }
    }
