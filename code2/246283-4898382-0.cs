    private void pictureBox1_Click(object sender, EventArgs e)
    {
                if (flagarrow == false)
                { 
                    flagarrow = true; 
                } 
                else 
                { 
                    flagarrow = false;
                }
                //Add this following line to repaint the picture box.
                pictureBox1.Refresh();
                       
    }
