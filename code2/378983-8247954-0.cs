            private bool AddGifFrames(Image image)
        {
            // implementation
            var fd = new FrameDimension(image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(fd);
            var frames = new List<Tuple<int, Image>>();
            if (frameCount > 1)
            {
                frames = new List<Tuple<int, Image>>();
                //0x5100 is the property id of the GIF frame's durations
                //this property does not exist when frameCount <= 1
                byte[] times = image.GetPropertyItem(0x5100).Value;
                for (int i = 0; i < frameCount; i++)
                {
                    //selects GIF frame based on FrameDimension and frameIndex
                    image.SelectActiveFrame(fd, i);
                    //length in milliseconds of display duration
                    int length = BitConverter.ToInt32(times, 4 * i);
                    //save currect image frame as new bitmap
                    frames.Add(new Tuple<int, Image>(length, new Bitmap(image)));
                }
            } // Not animated
            foreach (var frame in frames)
            {
                HandleFrame(frame.Item2, frame.Item1);
            }
            return true;
        }
