 c++
namespace cv {
	__noreturn void error(int a, const String & b, const char * c, const char * d, int e) {
		throw std::string(b);
	}
}
Sure, this is ugly and dirty way to do things, so if you know how to fix the linker error, please do so and let me know.
Now, you should have a working C++ code that compiles and can be run from a Unity Android application. The next thing is to save the image from ARCore, move it to C++ code, convert it and move it back. Let me start with the C# script, that you have as an component:
 C#
public Texture2D CameraToTexture()
    {
        Texture2D result;
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
            GCHandle YUVhandle = GCHandle.Alloc(YUVimage, GCHandleType.Pinned);
            GCHandle RGBhandle = GCHandle.Alloc(RGBimage, GCHandleType.Pinned);
            // Call the C++ function that we created.
            int k = ConvertYUV2RGBA(YUVhandle.AddrOfPinnedObject(), RGBhandle.AddrOfPinnedObject(), camBytes.Width, camBytes.Height);
            // If OpenCV conversion failed, return null
            if (k != 0)
            {
                Debug.LogWarning("Color conversion - k != 0");
                return null;
            }
            
            // Create a new texture object
            result = new Texture2D(camBytes.Width, camBytes.Height, TextureFormat.RGB24, false);
            // Load the RGB array to the texture
            result.LoadRawTextureData(RGBimage);
            // Save the texture as an PNG file. End the using {} clause to
dispose 
            File.WriteAllBytes(Application.persistentDataPath + "/tex.png", result.EncodeToPNG());
        }
        // Return the result.
        return result;
    }
