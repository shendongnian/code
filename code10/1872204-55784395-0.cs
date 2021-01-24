                    int sum = 0;
                    for (int i = 0; i < dataGridView2.Rows[0].Cells.Count; i++)
                    {
                        if (dataGridView2.Rows[0].Cells[i].Style.BackColor == 
                        Color.YellowGreen)
                        sum++;
                       {
                         if (sum > 2)
                       {
                          richTextBox2.Text = ("Cars");
                       }
                    }
                   
