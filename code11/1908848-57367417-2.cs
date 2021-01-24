        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            cont1++;
            updateColour(panel1, cont1);
        }
        //other panel 
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            cont2++;
            updateColour(panel2, cont2);
        }
        private void updateColour(Control ctrl, int count)
        {
            if (count >= 20)
            {
                ctrl.BackColor = Color.Red;
            }
            else if (count >= 15)
            {
                ctrl.BackColor = Color.Yellow;
            }
            else if (count >= 10)
            {
                ctrl.BackColor = Color.Lime;
            }
            else if (count >= 5)
            {
                ctrl.BackColor = Color.Cyan;
            }
            else
            {
                ctrl.BackColor = Color.SlateBlue;
            }
        }
