    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            MessageBox.Show("Left Clicked.");
        }
        else if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            MessageBox.Show("Right Clicked.");
        }
    } 
