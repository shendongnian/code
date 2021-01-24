        /// <summary>
        /// Converts Frame to Texture
        /// </summary>
        /// <returns>Texture2D</returns>
        public Texture2D FrameToTexture2D()
        {
            Texture2D frameTex = new Texture2D(Memory.spriteBatch.GraphicsDevice, Decoder.CodecContext->width, Decoder.CodecContext->height, false, SurfaceFormat.Color); //GC will collect frameTex
            const int bpp = 4;
            byte[] texBuffer = new byte[Decoder.CodecContext->width * Decoder.CodecContext->height * bpp]; 
            fixed (byte* ptr = &texBuffer[0])
            {
                byte*[] srcData = { ptr, null, null, null };
                int[] srcLinesize = { Decoder.CodecContext->width * bpp, 0, 0, 0 };
                // convert video frame to the RGB bitmap
                ffmpeg.sws_scale(ScalerContext, Decoder.Frame->data, Decoder.Frame->linesize, 0, Decoder.CodecContext->height, srcData, srcLinesize);
            }
            frameTex.SetData(texBuffer);
            return frameTex;
        }
