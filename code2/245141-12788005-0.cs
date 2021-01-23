    //Load Image
    Bitmap TestImage = new Bitmap(FileName);
    //Create Graphics Object
    Graphics g = Graphics.FromImage(TestImage);                   
    g.DrawEllipse(new Pen(Color.Red), i, j,0.5F, 0.5F);
    //View Your Results
    pictureBox1.Image = TestImage;
                 
                    
