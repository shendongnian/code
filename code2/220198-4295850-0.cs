        ToolTip t; 
        private void Form1_Load(object sender, EventArgs e)
        {
             t = new ToolTip();  //tooltip to control on which you are drawing your Image
        }
        
        Rectangle rect; //to store the bounds of your Image
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            rect =new Rectangle(50,50,200,200); // setting bounds to rect to draw image
            e.Graphics.DrawImage(yourImage,rect); //draw your Image
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (rect.Contains(e.Location)) //checking cursor Location if inside the rect
            {
                t.SetToolTip(Panel1, "Hello");//setting tooltip to Panel1
            }
            else
            {
                t.Hide(Panel1); //hiding tooltip if the cursor outside the rect
            }
        }
 
