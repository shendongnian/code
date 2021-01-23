    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter)
                { 
                    string LastLine = richTextBox1.Lines[richTextBox1.Lines.Length-2];
                    if (LastLine.StartsWith(">>"))
                    {
                        //here you can filter the LastLine
                        K2400.WriteString(LastLine, true);
                        richTextBox1.AppendText(K2400.ReadString() + Environment.NewLine);
                    }
                    else
                    {
                        //here you can unwrite the last line
                        string[] totalLines = richTextBox1.Lines;
                        richTextBox1.Text = "";
                        for (int i = 0; i < totalLines.Length - 2; i++)
                        {
                            richTextBox1.AppendText(totalLines[i]+Environment.NewLine);
                        }
                        MessageBox.Show("That was not a valid command");
                    }
                }
            }
