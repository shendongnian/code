      private void button1_Click(object sender, EventArgs e)
            {
                Find(richTextBox1, textBox1.Text, Color.Blue);
            }
            public static void Find(RichTextBox rtb, String word, Color color)
            {
                rtb.SelectionStart = 0;
                rtb.SelectionLength = rtb.TextLength;
                rtb.SelectionColor = Color.Black;
                if (word == "")
                {
                    return;
                }
                int s_start = rtb.SelectionStart, startIndex = 0, index;
                while ((index = rtb.Text.IndexOf(word, startIndex)) != -1)
                {
                    rtb.Select(index, word.Length);
                    rtb.SelectionColor = color;
                    startIndex = index + word.Length;
                }
            
            }
