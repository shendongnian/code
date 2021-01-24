      private void button1_Click(object sender, EventArgs e)
            {
                string line;
    
                List<PointF> polygonData = new List<PointF>();                          
                System.Drawing.Graphics g;
            
                //drawing on picture box
                g = Graphics.FromImage(pictureBox1.Image);                
                Pen p = new Pen(Color.Black, 5);
    
                //a loop to collect all points available in the file
                while ((line = file.ReadLine()) != null)                     
                {
                    var tokens = line.Split(splitChars);
    
                    lat = float.Parse(tokens[0].ToString());
                    longi = float.Parse(tokens[1].ToString());              
    
                    polygonData.Add(new PointF(lat, longi));
                  
                }
    
                if (polygonData.Count > 1)
                {
                    //draw polygon based on points parsed to the loop
                      g.DrawPolygon(p, polygonData.ToArray());
                    
                }
