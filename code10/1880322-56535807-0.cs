    private void button1_Click(object sender, EventArgs e)
            {
                //This line of code creates a text file for the data export.
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\your_path_here\\sample.txt");
                try
                {
                    string sLine = "";
    
                    //This for loop loops through each row in the table
                    for (int r = 0; r <= dataGridView1.Rows.Count - 1; r++)
                    {
                        //This for loop loops through each column, and the row number
                        //is passed from the for loop above.
                        for (int c = 0; c <= dataGridView1.Columns.Count - 1; c++)
                        {
                            sLine = sLine + dataGridView1.Rows[r].Cells[c].Value;
                            if (c != dataGridView1.Columns.Count - 1)
                            {
                                //A comma is added as a text delimiter in order
                                //to separate each field in the text file.
                                //You can choose another character as a delimiter.
                                sLine = sLine + ",";
                            }
                        }
                        //The exported text is written to the text file, one line at a time.
                        file.WriteLine(sLine);
                        sLine = "";
                    }
    
                    file.Close();
                    System.Windows.Forms.MessageBox.Show("Export Complete.", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception err)
                {
                    System.Windows.Forms.MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    file.Close();
                }
            }
