    public class MyWebClient: WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest wr = base.GetWebRequest(address);
            wr.AutomaticDecompression = DecompressionMethods.None;
            return wr;
        }
    }
