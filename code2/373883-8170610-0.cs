    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace CustomControl
    {
    public partial class Form1 : Form
    {
        Sprites Explosion = new Sprites();
        public Form1()
        {
            InitializeComponent();
            //insert your images in this next line
            Explosion.Images=new Image[]{Properties.Resources.explode1,Properties.Resources.explode2,Properties.Resources.explode3};
            Explosion.ImageIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //Draw the first image right away
            Explosion.Draw(panel1.CreateGraphics(), 0, 0);
            //set the index to the next image
            Explosion.ImageIndex++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if the Imageindex is not greater then the number of images
            if (Explosion.ImageIndex < Explosion.Images.Count() )
            {
                Explosion.Draw(panel1.CreateGraphics(), 0, 0);
                Explosion.ImageIndex++;
            }
            //if it is greater then reset the imageIndex and turn off the timer
            else
            {
                Explosion.ImageIndex = 0;
                timer1.Enabled = false;
                //Clear your images, however you need to do that
                panel1.CreateGraphics().Clear(Color.White);
            }
            
        }
    }
    public class Sprites
    {
        public Image DisplayedImage { get { return Images[ImageIndex]; } }
        public int ImageIndex;
        public Image[] Images;
        public void Draw(Graphics graphics, int x, int y)
        {
            graphics.DrawImage(DisplayedImage, x, y);
        }
        
    }
    }
