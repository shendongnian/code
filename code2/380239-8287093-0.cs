    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            //Basic dimensions of our "border" and our "image". Assumes 72 dots per inch which isn't technically correct but gives us something to work with
            private int BORDER_WIDTH = (int)11 * 72;
            private int BORDER_HEIGHT = (int)8.5 * 72;
            private int IMAGE_WIDTH = (int)2 * 72;
            private int IMAGE_HEIGHT = (int)3 * 72;
            private int IMAGE_OFFSET = 5;
    
            //These will store the x/y when we press our mouse down so that we can calculate the drag later
            private int offsetX;
            private int offsetY;
    
            //Our main "image" that we'll move around
            PictureBox pb;
            //The "border" to move the image around in
            PictureBox border;
    
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                //Resize the form and make it not user-resizable
                this.Size = new Size(BORDER_WIDTH + 30, BORDER_HEIGHT + 50);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                
                //Create our "image"
                pb = new PictureBox();
                pb.Size = new Size(IMAGE_WIDTH, IMAGE_HEIGHT);
                pb.Location = new Point(IMAGE_OFFSET, IMAGE_OFFSET);
                pb.BackColor = Color.Red;
                //Bind a handler to the mouse down event
                pb.MouseDown += new MouseEventHandler(this.pbMouseDown);
                this.Controls.Add(pb);
    
                //Create our "border"
                border = new PictureBox();
                border.Size = new Size(BORDER_WIDTH, BORDER_HEIGHT);
                border.Location = new Point(IMAGE_OFFSET, IMAGE_OFFSET);
                border.BackColor = Color.Black;
                this.Controls.Add(border);
            }
            private void pbMouseDown(object sender, MouseEventArgs e)
            {
                //Store the current x/y so that we can use them in calculations later
                offsetX = e.X;
                offsetY = e.Y;
                //When the mouse is down we want to remove the original mouse down handler
                pb.MouseDown -= new MouseEventHandler(this.pbMouseDown);
                //Add to more handler looking for mouse up and mouse movement
                pb.MouseUp += new MouseEventHandler(this.pbMouseUp);
                pb.MouseMove += new MouseEventHandler(this.pbMouseMove);
            }
            private void pbMouseUp(object sender, MouseEventArgs e)
            {
                //When the mouse button is released, remove old handlers and add back the down event
                pb.MouseMove -= new MouseEventHandler(this.pbMouseMove);
                pb.MouseUp -= new MouseEventHandler(this.pbMouseUp);
                pb.MouseDown += new MouseEventHandler(this.pbMouseDown);
                //Pop up a message, this is where something with iTextSharp would be done
                MessageBox.Show(String.Format("The top left of the image is at {0}x{1}", pb.Top - IMAGE_OFFSET, pb.Left - IMAGE_OFFSET));
            }
            private void pbMouseMove(object sender, MouseEventArgs e)
            {
                //Calculate where to draw the "image" at next
                //First, calculate based on the current image's location, the offset that we stored ealier and the current mouse position
                int newLeft = e.X + pb.Left - offsetX;
                int newTop = e.Y + pb.Top - offsetY;
                //Next, make sure that we haven't gone over one of the boundaries of the "border"
                if (newLeft < border.Left) newLeft = border.Left;
                if (newTop < border.Top) newTop = border.Top;
                if (newLeft + pb.Width > border.Right) newLeft = border.Right - pb.Width;
                if (newTop + pb.Height > border.Bottom) newTop = border.Bottom - pb.Height;
                //Finally, assign the new value
                pb.Left = newLeft;
                pb.Top = newTop;
            }
        }
    }
