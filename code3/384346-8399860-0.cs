      private void button1_Click_1(object sender, EventArgs e)
        {
            string word = textBox1.Text;
            foreach (char i in word)
            {
                switch (i)
                {
                    case 'a':
                    case 'A': { // play sound a
                        break;
                    }
                    default:
                        {
                            // play no sound
                            break;
                        }
                }
            }
        }
