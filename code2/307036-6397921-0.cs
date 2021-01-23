    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                DialogResult dialogresult = _form2.ShowDialog(this);
    
                if (dialogresult == DialogResult.OK)
                {                
                    rect.Width = 0;
                    rect.Height = 0;
                    pictureBox1.Invalidate();
                }
            } 
