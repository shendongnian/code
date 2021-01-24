                String sLine = "";
                try
                {
                    //Pass the file you selected with the OpenFileDialog control to
                    //the StreamReader Constructor.
                    System.IO.StreamReader FileStream = new System.IO.StreamReader(openFileDialog1.FileName);
                    //You must set the value to false when you are programatically adding rows to
                    //a DataGridView.  If you need to allow the user to add rows, you
                    //can set the value back to true after you have populated the DataGridView
                    dataGridView1.AllowUserToAddRows = false;
                    // Clear the DataGridView prior to reading a new text file
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    //Read the first line of the text file
                    sLine = FileStream.ReadLine();
                    //The Split Command splits a string into an array, based on the delimiter you pass.
                    //I chose to use a semi-colon for the text delimiter.
                    //Any character can be used as a delimeter in the split command.
                    //string[] s = sLine.Split(';');
                    string[] s = sLine.Split('\t');
                    //In this example, I placed the field names in the first row.
                    //The for loop below is used to create the columns and use the text values in
                    //the first row for the column headings.
                    for (int i = 0; i <= s.Count() - 1; i++)
                    {
                        DataGridViewColumn colHold = new DataGridViewTextBoxColumn();
                        colHold.Name = "col" + System.Convert.ToString(i);
                        colHold.HeaderText = s[i].ToString();
                        dataGridView1.Columns.Add(colHold);
                    }
                    //Read the next line in the text file in order to pass it to the
                    //while loop below
                    sLine = FileStream.ReadLine();
                    //The while loop reads each line of text.
                    while (sLine != null)
                    {
                        //Adds a new row to the DataGridView for each line of text.
                        dataGridView1.Rows.Add();
                        //This for loop loops through the array in order to retrieve each
                        //line of text.
                        for (int i = 0; i <= s.Count() - 1; i++)
                        {
                            //Splits each line in the text file into a string array
                            //s = sLine.Split(';');
                            s = sLine.Split('\t');
                            //Sets the value of the cell to the value of the text retreived from the text file.
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Value = s[i].ToString();
                        }
                        sLine = FileStream.ReadLine();
                    }
                    //Close the selected text file.
                    FileStream.Close();
                }
                catch (Exception err)
                {
                    //Display any errors in a Message Box.
                    System.Windows.Forms.MessageBox.Show("Error "+ err.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
