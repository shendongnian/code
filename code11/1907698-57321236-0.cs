      private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if((i+1)%2==1)
                {
                   string m= dataGridView1.Rows[i].Cells[1].Value.ToString();
                    Console.WriteLine(m);
                }
            }
        }
