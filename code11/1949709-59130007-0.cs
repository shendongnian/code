    private void Button4_Click(object sender, EventArgs e) 
            {
                string start = Directory.GetCurrentDirectory() + @"\Sav1.txt";
    
                using (var streamReader = new StreamReader(start))
                {
                    while (streamReader.Peek() > -1)
                    {
    
                        string[] values = streamReader.ReadLine().Split(' ');
    
                        Array.Sort(values);
    
                        Array.Reverse(values);
    
                        for (int i = 0; i < values.Length; i++)
                        {
                            richTextBox4.AppendText(values[i] + " ");
                        }
                    }
                }
