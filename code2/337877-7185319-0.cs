    panel1.MouseHover += new EventHandler(panel1_MouseHover);
    private void panel1_MouseHover(object sender, EventArgs e)
            {
                if (numericUpDown1.Focused)
                {
                    panel1.Focus();
                }
            }
