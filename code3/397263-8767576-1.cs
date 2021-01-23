    double topLeftX = 0;
    double topLeftY = 0;
    double bottomRightX = 0;
    double bottomrigthY = 0;
    bool setRect = false;
     
    private void ImageCanvas_MouseDown(object sender, MouseButtonEventArgs e)
    {
        topLeftY = topLeftX = bottomrigthY = bottomRightX = 0;
        setRect = true;
        System.Windows.Point pt = e.MouseDevice.GetPosition(sender as Canvas);
        topLeftX = pt.X; topLeftY = pt.Y;
    }
     
    private void ImageCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
        if (setRect == true)
        {
            //get mouse location relative to the canvas
            System.Windows.Point pt = e.MouseDevice.GetPosition(sender as Canvas);
            Canvas.SetLeft(ROI, topLeftX);
            Canvas.SetTop(ROI, topLeftY);
            ROI.Width = System.Math.Abs((int)(pt.X - topLeftX));
            ROI.Height = System.Math.Abs((int)(pt.Y - topLeftY));
            commandReturnTB.Text = (Convert.ToString(pt.X) + "," + Convert.ToString(pt.Y))+"\n";  
        }
    }
     
    private void ImageCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        System.Windows.Point pt = e.MouseDevice.GetPosition(sender as Canvas);
        bottomRightX = pt.X;
        bottomrigthY = pt.Y;
        ROI.Width = System.Math.Abs((int)(bottomRightX - topLeftX));
        ROI.Height = System.Math.Abs((int)(bottomrigthY - topLeftY));
        Canvas.SetLeft(ROI, topLeftX);
        Canvas.SetTop(ROI, topLeftY);
        setRect = false;
        commandReturnTB.Text = topLeftX + "," + topLeftY + "--" + bottomRightX + "," + bottomrigthY;
    }
