        DataTable dataTable = new DataTable();
         int count1,count2;
            clsInfor.northCON.Open();
            clsInfor.dataAdapter = new SqlDataAdapter("SELECT Discontinued, QuantityPerUnit FROM Products", clsInfor.northCON);
            dataTable = new DataTable();
            clsInfor.dataAdapter.Fill(dataTable);
            Excel.Application app = new Excel.Application(); //creating a new application
            app.Visible = true;
            Excel.Workbook book = app.Workbooks.Add(1); // creating an instance of the workbook 
            Excel.Worksheet sheet = (Excel.Worksheet)book.Worksheets[1]; // creating an instance of the worksheet
            ((Excel.Range)sheet.Cells[1, "A"]).Value2 = "Report"; // creating the header of the report
            ((Excel.Range)sheet.Cells[2, "B"]).Value2 = "Number of products per Cat";//creating the names of the colomns in the excell spreedsheet
            ((Excel.Range)sheet.Cells[2, "C"]).Value2 = "Number of products that have been discontinued";
            ((Excel.Range)sheet.Cells[4, "D"]).Value2 = "Tot number of Prod";
            for (count1 = 0; count1 < dataTable.Rows.Count; count1++)
            {
                for (count2 = 0; count2 < dataTable.Columns.Count; count2++)
                {
                    sheet.Cells[count1 + 3, count2 + 2] = dataTable.Rows[count1][count2];
                }
                sheet.Cells.Columns.AutoFit();
            }
