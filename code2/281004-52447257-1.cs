                    string[] lines = RichTextBox1.Lines.ToArray(); //This is to split the rich text box into an array
                    string richText = string.Empty;
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {//Here is were you re-build the text in the rich text box with lines that have some data in them
                            richText += line;
                            richText += Environment.NewLine;
                        }
                        else
                            continue;
                    }
                    richText = richText.Substring(0, richText.Length - 2); //Need to remove the last Environment.NewLine, else it will look at it as an other line in the rick text box.
                    RichTextBox1.Text = richText;
