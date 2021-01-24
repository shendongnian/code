    double price;
    bool isDouble = Double.TryParse(textBox1.Text, out price);
    if (isDouble)
    {
         Convert.ToDouble(textBox1.Text);
         dataGridView1[0, 0].Value = textBox1.Text;
    }
    else
    {
         dataGridView1[0, 0].Value = textBox1.Text;
    }
