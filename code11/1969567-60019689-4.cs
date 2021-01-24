        private void button1_Click(object sender, EventArgs e)
        {
            
            if (double.TryParse(textBox1.Text, out double costot) && int.TryParse(textBox2.Text, out int unidadesp) && unidadesp != 0)
            {
               var res = costot / unidadesp;
                textBox3.Text = res.ToString();
            }
        }
