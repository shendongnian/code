        private List<Image<Bgr, Byte>> GetVideoFrames(int Time_millisecounds)
        {
            List<Image<Bgr,Byte>> image_array = new List<Image<Bgr,Byte>>();
            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            
            bool Reading = true;
            Capture _capture = new Capture();
            SW.Start();
            while (Reading)
            {
                Image<Bgr, Byte> frame = _capture.QueryFrame();
                if (frame != null)
                {
                    image_array.Add(frame.Copy());
                    if (SW.ElapsedMilliseconds >= Time_millisecounds) Reading = false;
                }
                else
                {
                    Reading = false;
                }
            }
            return image_array;
        }
