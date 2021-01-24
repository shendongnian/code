        List<Rectangle> rectangles = new List<Rectangle>();
        private void addRectangle(int id, double xCoordinate, double yCoordinates)
        {
            //Create Rectangle and use the tag property to hold ID
            Rectangle newRectangle = new Rectangle() { Tag = id };
            Canvas.SetTop(newRectangle, yCoordinates);
            Canvas.SetLeft(newRectangle, xCoordinate);
            rectangles.Add(newRectangle);
        }
        private void alterRectangle(int id, double xCoordinate, double yCoordinates)
        {
            //Find the desired rectangle
            Rectangle r = (from rec in rectangles where Convert.ToInt16(rec.Tag) == id select rec).First();
            //Set the new coordinates
            Canvas.SetTop(r, yCoordinates);
            Canvas.SetLeft(r, xCoordinate);
        }
