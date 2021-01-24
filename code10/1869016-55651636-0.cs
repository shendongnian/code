            Console.WriteLine("Excel creating...");
            try
            {
                Random rnd = new Random();
                setlistview(_lw);
                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;
                int i = 1;
                int j = 1;
                foreach (ListViewItem item in lw.Items)
                {
                    ws.Cells[i, j] = item.Text.ToString();
                    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                    {
                        ws.Cells[i, j] = subitem.Text.ToString();
                        j++;
                    }
                    j = 1;
                    i++;
                }
                if (visible)
                {
                    Console.WriteLine("Mail with excel");
                    xla.Visible = false;
                    Console.WriteLine(Application.ExecutablePath.Substring(0, 2) + @"\Report_" + rnd.Next(1, 9999) + ".xlsx");
                    rapor = Application.ExecutablePath.Substring(0, 2) + @"\Report_" + rnd.Next(1, 9999) + ".xlsx";
                    wb.SaveAs(rapor);
                    wb.Close();
                    xla.Quit();
                    sendMail();
                }
