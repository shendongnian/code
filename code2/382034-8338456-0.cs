    int yPos = 0;    
    Panel myListBox = new Panel();
    foreach (Object object in YourObjectList)
    {
        Panel line = new Panel();
        line.Location = new Point(0, Ypos);
        line.Size = new Size(myListBox.Width, 20);
        line.MouseClick += new MouseEventHandler(line_MouseClick);
        myListBox.Controls.Add(line);
        // Add and arrange the controls you want in the line
        yPos += line.Height;
    }
