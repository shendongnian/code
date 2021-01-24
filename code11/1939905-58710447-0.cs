        public XLSFileResult() : base(@"application/vnd.ms-excel")
        {
            Data = new List<UP>();
        }
        public IEnumerable<UP> Data { get; set; }
        protected override void WriteFile(HttpResponseBase response)
        {
            string[] lines = Data.Select(d => string.Join(", ", d.Id, d.Name)).ToArray();
            byte[] buffer = response.ContentEncoding.GetBytes(string.Join(Environment.NewLine, lines));
            response.BinaryWrite(buffer);                       
        }
    }
