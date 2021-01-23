    public void plotTheValues(List<TheList> allValuesList)
    {
        foreach (TheList val in allValuesList)
        {
            Int16 x1 = val.xCoordinate;
            Int16 y1 = val.yCoordinate;
            g.DrawString("X", 
                         new Font("Calibri", 12), 
                         new SolidBrush(Color.Black), 
                         y + y1, x - x1);
            g.DrawImage(bmp,...); // It's really faster and memory saving
            // Are you sure you don't need to plot the image bmp
            // at item coordinates instead of always at the same position?
        }
    }
