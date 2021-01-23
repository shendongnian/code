        void nui_VideoFrameReady(object sender, ImageFrameReadyEventArgs e)
        {
            byte[] bits = e.ImageFrame.Image.Bits;
            for (int i = 0; i < bits.Length; i += 4)
            {
                frameBuffer[i] = bits[i + 2];
                frameBuffer[i + 1] = bits[i + 1];
                frameBuffer[i + 2] = bits[i];
            }
            canvas.SetData(frameBuffer);
        }
