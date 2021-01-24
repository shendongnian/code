    #region Loading the data to DataGridView
    DataSet customersDataSet = new DataSet();
     
    //Read the XML file with data
    string inputXmlPath = Path.GetFullPath(@"../../Data/Employees.xml");
    customersDataSet.ReadXml(inputXmlPath);
    DataTable dataTable = new DataTable();
                 
    //Copy the structure and data of the table
    dataTable = customersDataSet.Tables[1].Copy();
                 
    //Removing unwanted columns
    dataTable.Columns.RemoveAt(0);
    dataTable.Columns.RemoveAt(10);
    this.dataGridView1.DataSource = dataTable;
     
    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
    dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightBlue;
    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold)));
    dataGridView1.ForeColor = Color.Black;
    dataGridView1.BorderStyle = BorderStyle.None;
    #endregion
     
    using (ExcelEngine excelEngine = new ExcelEngine())
    {
        IApplication application = excelEngine.Excel;
     
        //Create a workbook with single worksheet
        IWorkbook workbook = application.Workbooks.Create(1);
     
        IWorksheet worksheet = workbook.Worksheets[0];
     
        //Import from DataGridView to worksheet
        worksheet.ImportDataGridView(dataGridView1, 1, 1, isImportHeader: true, isImportStyle: true);
     
        worksheet.UsedRange.AutofitColumns();
        workbook.SaveAs("Output.xlsx");
    }
