                    string[] lines = rtbInputMicrosoftKB.Lines.ToArray();
                    string richText = string.Empty;
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            richText += line;
                            richText += Environment.NewLine;
                        }
                        else
                            continue;
                    }
                    richText = richText.Substring(0, richText.Length - 2);
                    rtbInputMicrosoftKB.Text = richText;
