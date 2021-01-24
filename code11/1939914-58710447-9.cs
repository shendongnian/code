    public class XLSFileResult : FileResult
    {
        public XLSFileResult() : base(@"application/vnd.ms-excel")
        {
            Data = new List<UP>();
        }
        public IEnumerable<UP> Data { get; set; }
        protected override void WriteFile(HttpResponseBase response)
        {
            // note: implicit UserO.ToString() and ProductO.ToString() usage, 
            //       you'll want to handle this better before demoing this concept
            string[] lines = Data.Select(d => string.Join(", ", d.UserO, d.ProductO)).ToArray();
            byte[] buffer = response.ContentEncoding.GetBytes(string.Join(Environment.NewLine, lines));
            response.BinaryWrite(buffer);                       
        }
    }
