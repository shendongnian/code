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
               writer.Write(dataGridView1.Rows[x].Cells[0].Value);
               for (int i = 1; i < dataGridView1.Rows[x].Cells.Count; i++)
                   writer.Write("," + dataGridView1.Rows[x].Cells[i].Value);
               writer.Write("\n");
           }
           writer.Close();
       }
