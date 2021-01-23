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
        public Form1()
        {
            InitializeComponent();
            //insert your images in this next line
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Image[] explodingImages = new Image[] { Properties.Resources.explode1, Properties.Resources.explode2, Properties.Resources.explode3 };
            //initialize the explosion with the images from above
            Sprites Explosion = new Sprites(explodingImages,panel1.CreateGraphics());
            //the timer will start and it will draw all images from the above collection, then clear itself, then dispose of itself.
            Explosion.ImageIndex = 0;
        }
     
    }
    public class Sprites
    {
        private Image _DisplayedImage;
        public Image DisplayedImage
        {
            get { return _DisplayedImage; } 
        }
        private Image[] Images{get;set;}
        private int _ImageIndex = 0;
        
        public event EventHandler ImageIndexChanged;
        
        public int ImageIndex
        {
            get { return _ImageIndex; }
            set
            {
                //Changes thh ImageIndexNumber
                _ImageIndex = value;
                //Updates the Displayed Image with the current Image as per index
                _DisplayedImage = Images[ImageIndex];
                //fires the ImageIndexChanged Event (if required)
                if (ImageIndexChanged != null)
                    ImageIndexChanged(this, EventArgs.Empty);
                //draws the explosion to the graphics object
                DrawExplosion(G, 0, 0);
                //starts the timer
                changeImageTimer.Enabled = true;
            }
        }
        //local variable for the graphics object
        private Graphics G;
        //creats a timer for changing the Images
        Timer changeImageTimer = new Timer();
        //Constructor
        public Sprites(Image[] images,Graphics g)
        {
            //set the starting Images
            Images = images;
            //set the interval time to 5 seconds- in my opinion this number is rediculously high, but if that is what you want
            changeImageTimer.Interval = 5000;
            //Get the Tick event of the timer
            changeImageTimer.Tick += new EventHandler(changeImageTimer_Tick);
            //set the Graphics that you want to draw on
            G = g;
        }
        void changeImageTimer_Tick(object sender, EventArgs e)
        {
            int temp=ImageIndex+1;
            //if there are no more pictures to display stop the timer
            if (temp > Images.Count() - 1)
            {
                //stop the timer
                changeImageTimer.Enabled = false;
                //Clear the image, replace with your own background color, or draw an image or whatever you need to do to clear the images
                G.Clear(Color.White);
            }
            //if there are more pictures select the next picture
            else
                //Changeing the imageindex fires the draw method and the imageindexchanged event
                ImageIndex++;
        }
        public void DrawExplosion(Graphics graphics,int x, int y)
        {
            graphics.DrawImage(DisplayedImage, x, y);
        }
    }
    }
