    public Mat getCameraImage()
    {
        // Use using to make sure that C# disposes of the CameraImageBytes afterwards
        using (CameraImageBytes camBytes = Frame.CameraImage.AcquireCameraImageBytes())
        {
            // If acquiring failed, return null
            if (!camBytes.IsAvailable)
            {
                Debug.LogWarning("camBytes not available");
                return null;
            }
            // To save a YUV_420_888 image, you need 1.5*pixelCount bytes.
            // I will explain later, why.
            byte[] YUVimage = new byte[(int)(camBytes.Width * camBytes.Height * 1.5f)];
            // As CameraImageBytes keep the Y, U and V data in three separate
            // arrays, we need to put them in a single array. This is done using
            // native pointers, which are considered unsafe in C#.
            unsafe
            {
                for (int i = 0; i < camBytes.Width * camBytes.Height; i++)
                {
                    YUVimage[i] = *((byte*)camBytes.Y.ToPointer() + (i * sizeof(byte)));
                }
                for (int i = 0; i < camBytes.Width * camBytes.Height / 4; i++)
                {
                    YUVimage[(camBytes.Width * camBytes.Height) + 2 * i] = *((byte*)camBytes.U.ToPointer() + (i * camBytes.UVPixelStride * sizeof(byte)));
                    YUVimage[(camBytes.Width * camBytes.Height) + 2 * i + 1] = *((byte*)camBytes.V.ToPointer() + (i * camBytes.UVPixelStride * sizeof(byte)));
                }
            }
            // Create the output byte array. RGB is three channels, therefore
            // we need 3 times the pixel count
            byte[] RGBimage = new byte[camBytes.Width * camBytes.Height * 3];
            // GCHandles help us "pin" the arrays in the memory, so that we can
            // pass them to the C++ code.
            GCHandle pinnedArray = GCHandle.Alloc(YUVimage, GCHandleType.Pinned);
            IntPtr pointer = pinnedArray.AddrOfPinnedObject();
          
            Mat input = new Mat(camBytes.Height + camBytes.Height / 2, camBytes.Width, CvType.CV_8UC1);
            Mat output = new Mat(camBytes.Height, camBytes.Width, CvType.CV_8UC3);
            Utils.copyToMat(pointer, input);
            Imgproc.cvtColor(input, output, Imgproc.COLOR_YUV2RGB_NV12);
            pinnedArray.Free();
            return output;
        }
    }
