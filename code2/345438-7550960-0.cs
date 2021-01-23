        public void updateMap()
        {
            if (pbMap.InvokeRequired) // just if you call in thread
            {
                pbMap.Invoke(new Action(() => pbMap.Invalidate()));
            }
            else
            {
                pbMap.Invalidate();
            }
        }
