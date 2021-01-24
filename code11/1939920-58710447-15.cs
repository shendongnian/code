    public class XLSFileResult : FileResult
    {
        public XLSFileResult() : base(@"application/vnd.ms-excel")
        {
            Data = new List<UP>();
        }
        public IEnumerable<UP> Data { get; set; }
        protected override void WriteFile(HttpResponseBase response)
        {
            // note: you'll want to handle this better; I'm just choosing a property of each complex type.
            string[] lines = Data.Select(d => string.Join(", ", d.UserO.UserName , d.ProductO.PName)).ToArray();
            byte[] buffer = response.ContentEncoding.GetBytes(string.Join(Environment.NewLine, lines));
            response.BinaryWrite(buffer);                       
        }
    }
