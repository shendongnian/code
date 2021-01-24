    using (TextWriter tw = new StreamWriter("example.txt"))
    {
        for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        {
             for(int j = 0; j < dataGridView1.Columns.Count; j++)
             {
                 tw.Write($"{dataGridView1.Rows[i].Cells[j].Value.ToString()}");
   
                 if(!j == dataGridView1.Columns.Count - 1)
                 {
                    tw.Write(",");
                 }
             }
             tw.WriteLine();
         }
    }
