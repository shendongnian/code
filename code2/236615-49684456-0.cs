    try
                {
                    FileAttributes attr = File.GetAttributes(textBox1.Text);
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory) { }
                }
                catch (ArgumentException e1)
                {
                    result = false;
                }
                catch (IOException e2)
                {
                    if (e2.Message.Contains("The network path was not found."))
                    {
                        result = false;
                    }
                    else { result = true; }
                }
