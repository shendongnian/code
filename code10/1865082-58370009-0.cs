    using System;
    using System.IO;
    using System.Collections.Generic;
    using GoogleARCore;
    using UnityEngine;
    using OpenCvSharp;
    using System.Runtime.InteropServices;
 
    public class CamImage : MonoBehaviour
        {
     
        public static List<byte[]> AllData = new List<byte[]>();     
        public static void GetCameraImage()
            {
            Texture2D result;
            // Use using to make sure that C# disposes of the CameraImageBytes afterwards
            using (CameraImageBytes camBytes = Frame.CameraImage.AcquireCameraImageBytes())
            {
                // If acquiring failed, return null
                if (!camBytes.IsAvailable)
                {
                    Debug.LogWarning("camBytes not available");
                    return;
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
                Mat input = new Mat(camBytes.Height + camBytes.Height / 2, camBytes.Width, MatType.CV_8UC1, pointer);
                Mat output = new Mat(camBytes.Height, camBytes.Width, MatType.CV_8UC3);
                Cv2.CvtColor(input, output, ColorConversionCodes.YUV2BGR_NV12 );// YUV2RGB_NV12);
                Cv2.Transpose(output, output);
                Cv2.Flip(output, output, FlipMode.Y);
                result = Unity.MatToTexture(output);
                result.Apply();
                byte[] im = result.EncodeToJPG(100);
                AllData.Add(im);
                Destroy(result);
                pinnedArray.Free();
            }
            
        }
