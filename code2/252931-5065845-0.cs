        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rectangle rc = listBox1.GetItemRectangle(listBox1.SelectedIndex);
            LinearGradientBrush brush = new LinearGradientBrush(
                rc, Color.Transparent, Color.Red, LinearGradientMode.ForwardDiagonal);
            Graphics g = Graphics.FromHwnd(listBox1.Handle);
         
            g.FillRectangle(brush, rc);
        }
