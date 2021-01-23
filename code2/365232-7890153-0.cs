    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter)
                { 
                    string LastLine = richTextBox1.Lines[richTextBox1.Lines.Length-2];
                    if (LastLine.StartsWith(">>"))
                    {
                        //here you can filter the LastLine
                        K2400.WriteString(LastLine, true);
                        richTextBox1.Text += K2400.ReadString() + Environment.NewLine;
                    }
                    else
                    {
                        //here you can unwrite the last line
                        string[] totalLines = richTextBox1.Lines;
                        richTextBox1.Text = "";
                        for (int i = 0; i < totalLines.Length - 1; i++)
                        {
                            richTextBox1.Text += totalLines[i];
                        }
                        MessageBox.Show("That was not a valid command");
                    }
                }
            }
