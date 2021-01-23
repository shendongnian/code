void pictureBox1_Paint(object sender, PaintEventArgs e)
{
     // Assuming your constructor takes coordinates as parameters
     var t = new Test(0, 0, 100, 100);
     t.Draw(e.Graphics);
}
