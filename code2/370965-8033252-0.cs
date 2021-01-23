    for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
    {
       if(i =1 )
       {
          this.dataGridView1.Rows[1].Height =Grid.Rows[1].Height +  40;
       }elese
       {
          this.dataGridView1.AutoResizeRow(i);
       }
    }
