    private void File_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                // File dir
                Console.WriteLine(files[0].ToString());
                // Get mouse coords
                Point mouse = PointToScreen(e.GetPosition(this));
                Point pt = Mouse.GetPosition(worldMap);
                Point adjustedPt = new Point();
                adjustedPt.X = pt.X + mouse.X;
                adjustedPt.Y = pt.Y + mouse.Y;
                Location dropLoc = worldMap.ViewportPointToLocation(adjustedPt);
                GeoPushpin newPin = new GeoPushpin();
                newPin.Location = dropLoc;
                worldMap.Children.Add(newPin);
            }
        }
