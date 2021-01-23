    private void button2_Click(object sender, EventArgs e)
    {
        a = 2;
        pictureBox1_MouseClick(null,null);
        pictureBox1_MouseDoubleClick(null,null);
    
    }
    private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if(a > 1 && a <=3)
        {
            if(e!=null)
            {
                c[f] = e.X;
                c[d] = e.Y;
                a++;
                f++;
            }
        }
    }
