                        fs.WriteLine("<?xml version=\"1.0\"?>");
                        fs.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                        fs.WriteLine("<ss:Workbook xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
                        fs.WriteLine("    <ss:Styles>");
                        fs.WriteLine("        <ss:Style ss:ID=\"1\">");
                        fs.WriteLine("           <ss:Font ss:Bold=\"1\"/>");
                        fs.WriteLine("        </ss:Style>");
                        fs.WriteLine("    </ss:Styles>");
                        fs.WriteLine("    <ss:Worksheet ss:Name=\"Sheet1\">");
                        fs.WriteLine("        <ss:Table>");
                        for (int x = 0; x <= dgvReport.Columns.Count - 1; x++)
                        {
                            fs.WriteLine("            <ss:Column ss:Width=\"{0}\"/>", dgvReport.Columns[x].Width);
                        }
                        fs.WriteLine("            <ss:Row ss:StyleID=\"1\">");
                        for (int i = 0; i <= dgvReport.Columns.Count - 1; i++)
                        {
                            fs.WriteLine("                <ss:Cell>");
                            fs.WriteLine(string.Format("                   <ss:Data ss:Type=\"String\">{0}</ss:Data>", dgvReport.Columns[i].HeaderText));
                            fs.WriteLine("                </ss:Cell>");
                        }
                        fs.WriteLine("            </ss:Row>");
                        for (int intRow = 0; intRow <= dgvReport.RowCount - 2; intRow++)
                        {
                            fs.WriteLine(string.Format("            <ss:Row ss:Height =\"{0}\">", dgvReport.Rows[intRow].Height));
                            for (int intCol = 0; intCol <= dgvReport.Columns.Count - 1; intCol++)
                            {
                                fs.WriteLine("                <ss:Cell>");
                                fs.WriteLine(string.Format("                   <ss:Data ss:Type=\"String\">{0}</ss:Data>", (dgvReport.Rows[intRow].Cells[intCol].Value != null) ? dgvReport.Rows[intRow].Cells[intCol].Value.ToString() : string.Empty));
                                fs.WriteLine("                </ss:Cell>");
                            }
                            fs.WriteLine("            </ss:Row>");
                        }
                        fs.WriteLine("        </ss:Table>");
                        fs.WriteLine("    </ss:Worksheet>");
                        fs.WriteLine("</ss:Workbook>");
                        fs.Close();
