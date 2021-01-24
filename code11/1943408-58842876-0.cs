        int i = 0;
        
        private void PictureBox1_Click(object sender, EventArgs e)
        {            
            if (i == 0)
            {
                pictureBox1.Image = Properties.Resources.close;
                i++;
            }                   
                else
            {
                pictureBox1.Image = Properties.Resources.open;
                i--;
            }                               
        }
