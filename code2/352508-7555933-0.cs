                private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder newText = new StringBuilder();
            using (StreamReader tsr = new StreamReader(targetFilePath))
            {
                do
                {
                    string textLine = tsr.ReadLine() + "\r\n";
                    {
                        if (textLine.StartsWith("INSERT INTO"))
                        {
                            newText.Append(textLine + Environment.NewLine);
                        }
                    }
                }
                while (tsr.Peek() != -1);
                tsr.Close();
            }
            System.IO.TextWriter w = new System.IO.StreamWriter(@"C:\newFile.txt");
            w.Write(newText.ToString());
            w.Flush();
            w.Close();
        }
