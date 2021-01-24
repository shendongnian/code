        private void button2_Click(object sender, EventArgs e)
        {
            string test_string = textBox1.Text.Trim();
            if (!uint.TryParse(test_string, out uint test_UInt32))
            {
                MessageBox.Show("Invalid Input");
                return;
            }
            if (!UInt32.TryParse(textBox1.Text.Trim(), out uint username_UInt32))
            {
                MessageBox.Show("Invalid Input");
                return;
            }
            Debug.Print($"The input string is {test_string}, the resulting number is {test_UInt32}, of type {test_UInt32.GetType()}");
            //Output  The input string is 1234, the resulting number is 1234, of type System.UInt32
            Debug.Print($"The input string is {textBox1.Text}, the resulting number is {username_UInt32}, of type {username_UInt32.GetType()}");
            //Output  The input string is 1234, the resulting number is 1234, of type System.UInt32
        }
