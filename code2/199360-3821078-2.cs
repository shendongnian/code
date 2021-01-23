    class Form1
    {
        bool showPopup = false;
    
        void MouseHover(object sender, EventArgs e)
        {
            showPopup = true;
        }
    
        void MouseLeave(object sender, EventArgs e)
        {
            showPopup = false;
            toolTip.Hide(this);
        }
    
        void MouseMove(object sender, MouseEventArgs e)
        {
            if (showPopup) 
            {
                toolTip.Show("X: " + e.Location.X + "\r\nY: " + e.Location.Y, 
                             this, e.Location)
            }
        }
    }
