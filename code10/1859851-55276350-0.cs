    string datetime = DateTime.Now.ToString("yyyy-MM-dd-HHMM");
    string filePath = $@"C:\folder\Text{datetime}.txt";
    File.Create(filePath);
    TextWriter writer = new StreamWriter(path);
    for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
    {
         for(int j = 0; j < dataGridView1.Columns.Count; j++)
         {                        
              writer.Write("\t"+dataGridView1.Rows[i].Cells[j].Value.ToString()+"\t"+"|");
         }
         writer.WriteLine("");
         writer.WriteLine("-----------------------------------------------------");
    }
     writer.Close();
     MessageBox.Show("Data Exported");
