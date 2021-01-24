    public void writeToPort(Point coordinates)
    {
        var stringToWrite = String.Format("X{0}Y{1}",
           (coordinates.X / (Size.Width / 180)),
           (coordinates.Y / (Size.Height / 180)))
        port.Write(stringToWrite);
        Debug.WriteLine(stringToWrite);
    }
