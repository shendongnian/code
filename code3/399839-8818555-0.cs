            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow red = dataGridView1.Rows[i];
                for (int j = 0; j < red.Cells.Count-2; j++)
                {
                    if (j != 0)
                    {
                        xlApp.Cells[i + 1, j + 1] = "'" + Convert.ToString(red.Cells[j].Value);
                    }
                    else
                    {
                        xlApp.Cells[i + 1, j + 1] = Convert.ToString(red.Cells[j].Value);
                    }
                }
            }
    
            xlApp.AutoCorrect.ReplaceText = false;            
            saveFileDialog1.DefaultExt = ".xls";
            saveFileDialog1.FileName = textBox2.Text;
            saveFileDialog1.InitialDirectory = "Desktop";
            saveFileDialog1.ShowDialog();
            try
            {
                xlApp.ActiveWorkbook.SaveCopyAs(FileName);
            }
            catch
            {
                MessageBox.Show("Warning");
            }
            ImeDatoteke = "";
            xlApp.Quit();
    
