    public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log, ExecutionContext context)
            {
                var excelFilePath = context.FunctionDirectory + @"\Book.xlsx";
                var destinationCsvFilePath = context.FunctionDirectory + @"\test.csv";
    
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    
                var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    
                IExcelDataReader reader = null;
               
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
    
                var ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = false
                    }
                });
    
                var csvContent = string.Empty;
                int row_no = 0;
                while (row_no < ds.Tables[0].Rows.Count)
                {
                    var arr = new List<string>();
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        arr.Add(ds.Tables[0].Rows[row_no][i].ToString());
                    }
                    row_no++;
                    csvContent += string.Join(",", arr) + "\n";
                }
                StreamWriter csv = new StreamWriter(destinationCsvFilePath, false);
                csv.Write(csvContent);
                csv.Close();
    
                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            }
