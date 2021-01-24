    private void loadFileNames()
    {
         String[] files = Directory.GetFiles(@"C:\Users\m2104\Desktop\test");
         DataTable table = new DataTable();
         table.Columns.Add("File Name");
    
         for (int i = 0; i < files.Length; i++)
         {
              FileInfo file = new FileInfo(files[i]);
              DataRow dr = table.NewRow();
              dr[0] = file.Name;
              table.Rows.Add(dr);
         }
    
         dataGridView1.DataSource = table;
    
      }
