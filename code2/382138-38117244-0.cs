    private void button1_Click(object sender, EventArgs e)
    {
    
        ColorDialog cd = new ColorDialog();
        if (cd.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show(cd.Color.ToString());
            pictureBox1.BackColor = cd.Color;
        }
    
    }
