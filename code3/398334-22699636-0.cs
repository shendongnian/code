    public partial class Form1 : Form
    {
        private int lastX;
        private int lastY;
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X != this.lastX || e.Y != this.lastY)
            {
                toolTip1.SetToolTip(button1, "test");
                this.lastX = e.X;
                this.lastY = e.Y;
            }
        }
