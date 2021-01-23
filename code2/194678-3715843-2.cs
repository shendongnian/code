        private void ProcessExcel(string filepath)
        {
                Excel.ApplicationClass ExcelObj = new Excel.ApplicationClass();
                Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(filepath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Sheets sheets = theWorkbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
                Excel.Range range = worksheet.UsedRange;
                System.Array myvalues = (System.Array)range.Cells.Value2;
                int vertical = myvalues.GetLength(0);
                int horizontal = myvalues.GetLength(1);
                
                string[] headers = new string[horizontal];
                string[] data = new string[horizontal];
                DataTable ResultsHeader = New DataTable();
                DataSet ds = New DataSet();
                for (int x = 1; x <= vertical; x++)
                {
                        Utils.inicializarArrays(datos);
                        for (int y = 1; y <= horizontal; y++)
                        {
                            if (x == 1)
                            {
                                headers[y - 1] = myvalues.GetValue(x, y).ToString();
                            }
                            else
                            {
                                string auxdata = "";
                                if (myvalues.GetValue(x, y) != null)
                                    auxdata = myvalues.GetValue(x, y).ToString();
                                data[y - 1] = auxdata;
                            }
                        }
                        if(x == 1) //headers
                        {
                                for(int w = 0; w < horizontal; w++)
                                {
                                        ResultsHeader.Columns.Add(New DataColumn(headers[w], GetType(string)));
                                }
                                ds.Tables.Add(ResultsHeader);
                        }
                        else
                        {
                                DataRow dataRow = ds.Tables[0].NewRow();
                                for(int w = 0; w < horizontal; w++)
                                {
                                        dataRow(headers[w]) = data[w]
                                }
                                ds.Tables[0].Rows.Add(dataRow);
                        }
                }
                DataView myDataView = new DataView();
                myDataView.Table = ds.Tables[0];
                MydataGrid.CurrentPageIndex = 0;
                MydataGrid.DataSource = myDataView;
                MydataGrid.DataBind();
        }
