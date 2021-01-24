    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            
            bool isBtnClick = false;
            System.Drawing.SolidBrush newColor;
            public Rectangle rect = new Rectangle(400, 80, 25, 25);
            public Form1()
            {
                InitializeComponent();
                
            }
           
           
          
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                if (isBtnClick == false)
                {
                   
                    System.Drawing.SolidBrush fillRed = new System.Drawing.SolidBrush(Color.Red);
    
                    e.Graphics.FillRectangle(fillRed, rect);
                }
                else
                {
                  
    
                    e.Graphics.FillRectangle(newColor, rect);
                }
              
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
    
                newColor = new System.Drawing.SolidBrush(Color.Blue); //New Color
                isBtnClick = true;
                panel1.Invalidate();
            }
        }
    }
