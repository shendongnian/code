       class Program
        {
            static void Main(string[] args)
            {
                List<InvoceHeader> headers = new List<InvoceHeader>();
                List<InvoiceHierarchi> hierarchi = new List<InvoiceHierarchi>();
                var query = (from header in headers
                             join hierarch in hierarchi on header.DocumentNumber equals hierarch.Certificate
                             select new { header = header, hierarch = hierarch }
                             ).ToList();
                Dictionary<string, object> dict = query
                    .GroupBy(x => x.header.DocumentNumber, y => new { header = y.header, hierachi = y.hierarch })
                    .ToDictionary(x => x.Key, y => (object)y.ToList());
            }
      
     
        }
        public class InvoceHeader
        {
            public int InvoiceId { get; set; }
            public string DocumentNumber { get; set; }
            public string DocumentDate { get; set; }
            public string DocumentReference { get; set; }
        }
        public class InvoiceHierarchi
        {
            public string SerialNumber { get; set; }
            public string ProductCode { get; set; }
            public string Certificate { get; set; }
            public string Description { get; set; }
        }
