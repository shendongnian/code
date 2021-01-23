           //OnExportGridToCSV(); 
           StreamWriter writer = new StreamWriter("C:\\scripts\\file.csv");
           // Write columns
           writer.Write(dataGridView1.Columns[0].HeaderText);
           for (int i = 1; i < dataGridView1.Columns.Count; i++)
               writer.Write("," + dataGridView1.Columns[i].HeaderText);
           writer.Write("\n");
           // Write values
           for (int x = 0; x < dataGridView1.Rows.Count; x++)
           {
               writer.Write(dataGridView1.Rows[x].Cells[0].FormattedValue.ToString());
               for (int i = 1; i < dataGridView1.Rows[x].Cells.Count; i++)
                   writer.Write("," + dataGridView1.Rows[x].Cells[i].FormattedValue.ToString());
               writer.Write("\n");
               textBox5.Text = ("Row " + (x + 1).ToString() + " of " + dataGridView1.Rows.Count + " exported."); // progress indicator
           }
           writer.Close();
         
           // open up the newly created file in excel 
           Process proc = new Process();
           proc.StartInfo = new ProcessStartInfo("excel.exe", "C:\\scripts\\file.csv");
           proc.Start();
       }
