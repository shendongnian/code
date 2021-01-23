    private void button1_Click(object sender, EventArgs e)
        {
            RandomNumber(0,99);
            button2.Enabled = true ;
            button1.Enabled = false;
            if (textBox1.Text == label1.Text)
                MessageBox.Show("Winner");
            if (textBox1.Text != label1.Text)
                MessageBox.Show( String.Format("Sorry - You Lose, The number is{0}",label1.Text));            
        }
