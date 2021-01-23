    private void button3_Click(object sender, EventArgs e)//Clear button
            {
            using (g = Graphics.FromImage(bmp))
            {
               g.Clear(Color.Transparent);//you can choose another color for your background here.
               panel1.Invalidate();
            }
        }
