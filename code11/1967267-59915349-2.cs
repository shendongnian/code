    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            
            bool isRectClick = false;
            System.Drawing.SolidBrush newColor;
            public Rectangle rect = new Rectangle(200, 100, 50, 50);
            public Form1()
            {
                InitializeComponent();
                
            }
           
           
          
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                if (isRectClick == false)
                {
                   
                    System.Drawing.SolidBrush fillRed = new System.Drawing.SolidBrush(Color.Red);
    
                    e.Graphics.FillRectangle(fillRed, rect);
                }
                else
                {
                  
    
                    e.Graphics.FillRectangle(newColor, rect);
                }
              
            }
            private void panel1_MouseDown(object sender, MouseEventArgs e)
            {
                if (this.rect.Contains(e.Location))
                {
                    newColor = new System.Drawing.SolidBrush(Color.Blue); //New Color
                    isRectClick = true;
                    panel1.Invalidate();
                }
               
            }
           
        }
    }
