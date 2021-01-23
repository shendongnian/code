    //Random rv = new Random();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Use for loop if you want multiple..
            Graphics surfac = this.CreateGraphics();
            Pen p = new Pen(System.Drawing.Color.Blue, 2.0f);
            Rectangle rect = new Rectangle(10,10,100,100);
            // Increment these values to get bays placed as rectangles
            surfac.DrawRectangle(p, rect);
        }
