            Point LastLocation = Point.Empty;
    
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                Debug.WriteLine("=> Form1_MouseDown, Clicks: " + e.Location + ", Location: " + e.Location + "");
            }
    
            private void Form1_MouseUp(object sender, MouseEventArgs e)
            {
                Debug.WriteLine("=> Form1_MouseUp, Clicks: " + e.Location + ", Location: " + e.Location + "");
    
            }
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                if (LastLocation != e.Location)
                {
                    LastLocation = e.Location;
                    Debug.WriteLine("=> Form1_MouseMove, Clicks: " + e.Location + ", Location: " + e.Location + "");
                }
            }
