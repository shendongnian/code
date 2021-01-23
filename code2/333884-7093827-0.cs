    public class ReplaceHTML : System.IO.Stream
    {
        private System.IO.Stream Base;
        public ReplaceHTML(System.IO.Stream ResponseStream)
        {
            if (ResponseStream == null)
            {
                throw new ArgumentNullException("ResponseStream");
            }
            this.Base = ResponseStream;
        }
    }
