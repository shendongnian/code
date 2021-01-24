        private void button1_Click(object sender, EventArgs e)
        {
            List<string> lines = new List<string>(textBox1.Lines);
            for(int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(".click()"))
                {
                    lines.Insert(i + 1, "sleep(5)");
                    i = i + 2;
                    // Helpers.ReturnMessage(line);
                }                
            }
            textBox1.Lines = lines.ToArray();
        }
