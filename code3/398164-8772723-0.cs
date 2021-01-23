        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            try
            {
                //Set filestream to the result of the pick of the user
                using (var fStr = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    //Create a streamreader, sr, to read the file
                    using (var sr = new StreamReader(fStr))
                    {
                        var sbTextBox1 = new System.Text.StringBuilder(10000);
                        var sbTextBox2 = new System.Text.StringBuilder(10000);
                        //While the end of the file has not been reached...
                        while (sr.Peek() >= 0)
                        {
                            //Create a 'line' that contains the current line of the textfile
                            string line = sr.ReadLine().ToLower();
                            if (line.Contains("staff"))
                            {
                                //Add a , to the end of the line**Important**
                                sbTextBox1.Append(",").Append(line).AppendLine();
                                releventcount += 1;
                            }
                            else
                            {
                                //Add a , to the end of the line**Important**
                                sbTextBox1.Append(",").Append(line).AppendLine();
                                irreleventcount += 1;
                            }
                        }
                        textBox1.Text = sbTextBox1.ToString();
                        textBox2.Text = sbTextBox2.ToString();
                        label1.Text = "Relevent: ";
                        label2.Text = "Irrelevant: ";
                        //Close the file so other modules can access it
                        sr.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening file", "Check the CODE ! ~.~");
            }
        }
