    var faults = new CheckBox[20];
    
    Point startPoint = new Point(20, 10);
    
    for (int i = 0; i < faults.Length; i++)
    {
        Controls.Add(new CheckBox()
        {
            Location = new Point(startPoint.X, 20 * i + startPoint.Y),
            Text = (i + 1).ToString()
        });
    }
