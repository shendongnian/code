    private void initAnimatableGridRectangles()
    {
        int index = 1;
        foreach (Rectangle rect in SequenceGrid.Children)
        {
            SolidColorBrush tempBrush = new SolidColorBrush();
            rect.Fill = tempBrush;
            string brushName = "Brush" + index;
            _gridBrushes.Add(brushName, tempBrush);
            this.RegisterName(brushName, tempBrush);
            Storyboard tempSBToGray = new Storyboard();
            Storyboard tempSBToWhite = new Storyboard();
            ColorAnimation tempColAnimToGray = getAnimToGray();
            ColorAnimation tempColAnimToWhite = getAnimToWhite();
            tempSBToGray.Children.Add(tempColAnimToGray);
            tempSBToWhite.Children.Add(tempColAnimToWhite);
            Storyboard.SetTargetName(tempColAnimToGray, brushName);
            Storyboard.SetTargetName(tempColAnimToWhite, brushName);
            Storyboard.SetTargetProperty(tempColAnimToGray, new PropertyPath(SolidColorBrush.ColorProperty));
            Storyboard.SetTargetProperty(tempColAnimToWhite, new PropertyPath(SolidColorBrush.ColorProperty));
            _animatableGridRectToGray.Add(tempSBToGray);
            _animatableGridRectToWhite.Add(tempSBToWhite);
            index++;
        }
    }
    private ColorAnimation getAnimToGray()
    {
        ColorAnimation colAnim = new ColorAnimation();
        colAnim.To = Colors.Gray;
        colAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));
        colAnim.AutoReverse = false;
        return colAnim;
    }
    private ColorAnimation getAnimToWhite()
    {
        ColorAnimation colAnim = new ColorAnimation();
        colAnim.To = Colors.White;
        colAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));
        colAnim.AutoReverse = false;
        return colAnim;
    }
