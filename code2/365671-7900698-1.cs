        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (map.ContainsKey(e.KeyChar))
            {
                if (curr == null || e.KeyChar != currChar)
                {
                    curr = map[e.KeyChar];
                    index = 0;
                    currChar = e.KeyChar;
                    Print();
                }
                else
                {
                    ++index;
                    if (index == curr.Length)
                        index = 0;
                    Print();
                }
            }
        }
