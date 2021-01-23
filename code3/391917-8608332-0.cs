    Point newLoc = new Point(5,5); // Set whatever you want for initial location
    for(int i=0; i < 10; ++i)
    {
        Button b = new Button();
        b.Size = new Size(10, 50);
        b.Location = newLoc;
        newLoc.Offset(0, b.Height + 5);
        Controls.Add(b);
    }
