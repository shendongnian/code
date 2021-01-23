    public class WcfStream : Stream
    {
        public Stream SQLStream { get; set; }
        public event EventHandler StreamClosedEventHandler;
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                SQLStream.Dispose();
                if (this.StreamClosedEventHandler != null)
                {
                    this.StreamClosedEventHandler(this, new EventArgs());
                }
            }
            base.Dispose(disposing);
        }
    }
