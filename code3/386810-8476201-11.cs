        private List<Image<Bgr, Byte>> GetVideoFrames(String Filename)
        {
            List<Image<Bgr,Byte>> image_array = new List<Image<Bgr,Byte>>();
            Capture _capture = new Capture(Filename);
            bool Reading = true;
            while (Reading)
            {
                Image<Bgr, Byte> frame = _capture.QueryFrame();
                if (frame != null)
                {
                    image_array.Add(frame.Copy());
                }
                else
                {
                    Reading = false;
                }
            }
            return image_array;
        }
