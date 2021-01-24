    btn.Click() // click to start measuring
    {
        Port.DiscardInBuffer();
        blToMeasure = true;
    }
    while (blToMeasure) // true after clicking on button
    {
        iPrevY = iY;
        try {
            iY = Int16.Parse(serialPort.ReadLine());
        }
        catch
        {
            // exception logic
        }
        graphicsGraph.DrawLine(penBlack, iX, iPrevY, iX + 1, iY);
        // only this thread is accessing PictureBox
        iX++;
        if (iX > picBoxGraph.Width)
        {
             graphicsGraph.Clear(SystemColors.Control);
             iX = 0;
        }
        if (iY > picBoxGraph.Height)
        {
        }
    }
