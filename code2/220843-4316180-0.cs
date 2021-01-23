                StreamWriter writer = new StreamWriter("file.csv");
                // Write columns
                writer.Write(myGridView.Columns[0].HeaderText);
                for (int i = 1; i < myGridView.Columns.Count; i++)
                    writer.Write("," + myGridView.Columns[i].HeaderText);
                writer.Write("\n");
                // Write values
                for (int x = 0; x < myGridView.Rows.Count; x++)
                {
                    writer.Write(myGridView.Rows[x].Cells[0].Text);
                    for (int i = 1; i < myGridView.Rows[x].Cells.Count; i++)
                        writer.Write("," + myGridView.Rows[x].Cells[i].Text);
                    writer.Write("\n");
                }
                writer.Close();
