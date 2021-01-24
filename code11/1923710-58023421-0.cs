    private void button1_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("DiscPort");
                dt.Columns.Add("Bag");
                dt.Columns.Add("Bulk ");
                dt.Columns.Add("Clinker ");
                dt.Columns.Add("CContainer");
                dt.Rows.Add(0, 15353.02,0,0,120);
                dt.Rows.Add(0, 0, 38602.393, 0,120);
                dt.Rows.Add(0, 15244.26, 0, 0,130);
                dt.Rows.Add(0, 15353.02, 0, 5600,0);
    
                foreach (DataColumn item in dt.Columns)
                {
                    item.ColumnName = "Sum of " + item.ColumnName;
                }
                double discport = 0;
                double bag = 0;
                double bulk = 0;
                double Clinker = 0;
                double CContainer = 0;
       
                foreach (DataRow item in dt.Rows)
                {
                    discport += Convert.ToDouble(item[0]);
                    bag+= Convert.ToDouble(item[1]);
                    bulk+= Convert.ToDouble(item[2]);
                    Clinker+= Convert.ToDouble(item[3]);
                    CContainer+= Convert.ToDouble(item[4]);
                }
                dt.Rows.Add(discport, bag, bulk, Clinker, CContainer);
                converttoexcel("D:\\convert.xlsx", dt);
                MessageBox.Show("Test");
    
            }
            public void converttoexcel(string path, DataTable table)
            {
                XLWorkbook workbook = new XLWorkbook();
                table.TableName = "sheet1";
                workbook.Worksheets.Add(table);
                workbook.SaveAs(path);
            }
