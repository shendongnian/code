    internal class Program
    {
        private static DataTable CreateDataTable( IEnumerable<object[]> rawData )
        {
            var datatable = new DataTable();
            datatable.Columns.Add("INVOICE_NO");
            datatable.Columns.Add("INVOICE_DATE");
            datatable.Columns.Add("CODE");
            datatable.Columns.Add("SERVICE_DESCRIPTION");
            datatable.Columns.Add("QTY", typeof(decimal));
            datatable.Columns.Add("UNIT_PRICE", typeof(decimal));
            datatable.Columns.Add("GROSS", typeof(decimal));
            datatable.Columns.Add("DISCOUNT", typeof(decimal));
            datatable.Columns.Add("NET", typeof(decimal));
            datatable.Columns.Add("DEDUCTION", typeof(decimal));
            datatable.Columns.Add("NET_PAYABLE_WITHOUT_VAT", typeof(decimal));
            datatable.Columns.Add("VAT", typeof(decimal));
            datatable.Columns.Add("NET_PAYABLE_WITH_VAT", typeof(decimal));
            foreach (var row in rawData)
            {
                datatable.Rows.Add(row);
            }
            return datatable;
        }
        
        public static void Main(string[] args)
        {
            var rowData = new List<object[]>()
            {
                new object[] { "CR100005", "25-05-1989", "CPT004", "SERVICE005", 1, 10, 100, 10, 90,
                    45, 45, 5, 50 },
                new object[] { "CR100006", "25-05-1992", "CPT00555", "SERVICE105", 6, 60, 600, 60,
                450, 45, 45, 5, 500 }
            };
            
            var pdfModule = new PdfModule();
            var outDirectory = Path.Combine(Environment.CurrentDirectory, "Output");
            if (!Directory.Exists(outDirectory))
            {
                // well theoretically I should just create the directory and worry about conflicts differently
                Directory.CreateDirectory(outDirectory);
            }
            Console.WriteLine( $"Creating files to {outDirectory}");
            var nrOfFiles = 100000;
            var stepCount = 1000;
            for (var i = 0; i < nrOfFiles; i++)
            {
                if (i % stepCount == 0)
                {
                    Console.WriteLine($"Creating files {i}-{i+stepCount-1}" );
                }
                var filename = Path.Combine(outDirectory, $"{i}.pdf");
                using (var dataTable = CreateDataTable(rowData))
                {
                    pdfModule.CreateFile(filename, dataTable);
                }
            }
            Console.WriteLine($"Done, created {nrOfFiles} files");
        }
    }
