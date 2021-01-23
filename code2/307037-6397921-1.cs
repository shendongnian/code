    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                if (TwoClicks < 2)
                {
                TwoClicks++;
                DialogResult dialogresult = _form2.ShowDialog(this);
    
                if (dialogresult == DialogResult.OK)
                {                
                    rect.Width = 0;
                    rect.Height = 0;
                    pictureBox1.Invalidate();
                }
                }
            }
