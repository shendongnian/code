    public List<double[]> getColor(List<Point> cordinates, Mat image)
        {
            int r = 0, g = 0, b = 0, a = 0;
            List<double[]> colorlist = new List<double[]>();
            List<double[]> colorAvg = new List<double[]>();
            for (int i = 0; i < cordinates.Count; i++)
            {
                int x = (int)cordinates[i].x;
                int y = (int)cordinates[i].y;
                double[] color = image.get(x, y);
                colorlist.Add(color);
                r = (r + (int)colorlist[i][0]);
                g = (g + (int)colorlist[i][1]);
                b = (b + (int)colorlist[i][2]);
                a = (a + (int)colorlist[i][3]);              
                //Debug.Log("Color: "+ color.GetValue(0)+ "-"+ color.GetValue(1) + "-" + color.GetValue(2) + "-" + color.GetValue(3));
            }
            r = r / colorlist.Count;
            g = g / colorlist.Count;
            b = b / colorlist.Count;
            a = a / colorlist.Count;
            colorAvg.Add(new double[4] { r, g, b, a } );
            // Average R-G-B-A values
            Debug.Log("Avg R:" + colorAvg [0][0]);
            Debug.Log("Avg G:" + colorAvg [0][1]);
            Debug.Log("Avg B:" + colorAvg [0][2]);
            Debug.Log("Avg A:" + colorAvg [0][3]);
            return colorAvg ;
        }
