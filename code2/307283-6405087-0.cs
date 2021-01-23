        textBox1.Validating += new CancelEventHandler(textBox1_Validating);
        void textBox1_Validating(object sender, CancelEventArgs e)
        {
            int numberEntered;
            if (int.TryParse(textBox1.Text, out numberEntered))
            {
                if  (numberEntered < 1 || numberEntered > 10) 
                { 
                    MessageBox.Show("You have to enter a number between 1 and 10");
                    textBox1.Text = 5.ToString();
                }
            }
            else
            {
                MessageBox.Show("You need to enter an integer");
                textBox1.Text = 5.ToString();
            }
        }
