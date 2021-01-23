            string[] lines = richTextBox1.Lines;
            for (int line = 0; line < lines.Length; line++)
            {
                string replacement1 = richTextBox2.Lines[line];
                while (replacement1.Length < 7)
                {
                    replacement1 = " " + replacement1;
                }
                lines[line] = lines[line].Remove(20, 7).Insert(20, replacement1);
                string replacement2 = richTextBox3.Lines[line];
                while (replacement2.Length < 7)
                {
                    replacement2 = " " + replacement2;
                }
                lines[line] = lines[line].Remove(29, 7).Insert(29, replacement1);
            }
            richTextBox1.Lines = lines;
