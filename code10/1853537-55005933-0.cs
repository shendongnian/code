        public double ReSizeWidth
        {
            get
            {
                return ((float)SystemParameters.VirtualScreenWidth) * (1500f / 2560f); 
                // 1500f / 2560f is the percentage
            }
        }
        public double ReSizeHeight
        {
            get
            {
                return ReSizeWidth * 0.75f + 32;
                // keep the window aspect ratio
            }
        }
