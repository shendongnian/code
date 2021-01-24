    private void button1_Click(object sender, EventArgs e) 
    { 
        textBox1.Text = (int.Parse(szam1.Text) * int.Parse(szazalek1.Text)).ToString(); 
    }
    private void button2_Click(object sender, EventArgs e)
    {
        eredmeny2.Text = "," + (int.Parse(szam2.Text) * int.Parse(szazalek2.Text)).ToString();
    }
