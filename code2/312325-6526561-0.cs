    private void exportCsv()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            createSaveDialog(saveFile, ".csv", "CSV (*csv)|*.csv)");
            TextWriter writer = new StreamWriter(saveFile.FileName);
            int row = dataGridView1.Rows.Count;
            int col = dataGridView1.Columns.Count;
            try
            {
                if (saveFile.FileName != "")
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        writer.Write(dataGridView1.Columns[i].HeaderText + ",");
                    }
                    writer.Write("\r\n");
                    for (int j = 0; j < row - 1; j++)
                    {
                        for (int k = 0; k < col - 1; k++)
                        {
                            writer.Write(dataGridView1.Rows[j].Cells[k].Value.ToString() + ",");
                        }
                        writer.Write("\r\n");
                    }
                }
                MessageBox.Show("File Sucessfully Created!", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("File could not be created.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                writer.Close();
                saveFile.Dispose();
            }
        }
