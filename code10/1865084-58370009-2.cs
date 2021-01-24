c#
        using System;
        using System.Collections.Generic;
        using GoogleARCore;
        using UnityEngine;
        using OpenCvSharp;
        using System.Runtime.InteropServices;
    
        public class CamImage : MonoBehaviour
        {
    
            public static List<Mat> AllData = new List<Mat>();
    
            public static void GetCameraImage()
            {
    
                // Use using to make sure that C# disposes of the CameraImageBytes afterwards
                using (CameraImageBytes camBytes = Frame.CameraImage.AcquireCameraImageBytes())
                {
    
                    // If acquiring failed, return null
                    if (!camBytes.IsAvailable)
                    {
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
    
                    // GCHandles help us "pin" the arrays in the memory, so that we can
                    // pass them to the C++ code.
                    GCHandle pinnedArray = GCHandle.Alloc(YUVimage, GCHandleType.Pinned);
    
                    IntPtr pointerYUV = pinnedArray.AddrOfPinnedObject();
    
                    Mat input = new Mat(camBytes.Height + camBytes.Height / 2, camBytes.Width, MatType.CV_8UC1, pointerYUV);
                    Mat output = new Mat(camBytes.Height, camBytes.Width, MatType.CV_8UC3);
    
                    Cv2.CvtColor(input, output, ColorConversionCodes.YUV2BGR_NV12);// YUV2RGB_NV12);
    
                    // FLIP AND TRANPOSE TO VERTICAL
                    Cv2.Transpose(output, output);
                    Cv2.Flip(output, output, FlipMode.Y);
    
                   AllData.Add(output);
                   pinnedArray.Free();
                }
                
            }
        }
I then call ExportImages() when exiting the program to save to file.
        private void ExportImages()
        {
            /// Write Camera intrinsics to text file
            var path = Application.persistentDataPath;
            StreamWriter sr = new StreamWriter(path + @"/intrinsics.txt");
            sr.WriteLine(CameraIntrinsicsOutput.text);
            Debug.Log(CameraIntrinsicsOutput.text);
            sr.Close();
            // Loop through Mat List, Add to Texture and Save.
            for (var i = 0; i < CamImage.AllData.Count; i++)
            {
                Mat imOut = CamImage.AllData[i];
                Texture2D result = Unity.MatToTexture(imOut);
                result.Apply();
                byte[] im = result.EncodeToJPG(100);
                string fileName = "/IMG" + i + ".jpg";
                File.WriteAllBytes(path + fileName, im);
                string messge = "Succesfully Saved Image To " + path + "\n";
                Debug.Log(messge);
                Destroy(result);
            }
        }
