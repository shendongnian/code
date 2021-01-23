    using System;
    using System.Drawing;
    using Microsoft.Expression.Encoder.ScreenCapture;
    // Added references to:
    // Microsoft.Expression.Encoder
    // Microsoft.Expression.Encoder.Types
    // Microsoft.Expression.Encoder.Utilities
    // WindowsBase
    // System.Drawing (for Rectangle)
    namespace scrcap
    {
        class Program
        {
            static void Main(string[] args)
            {
                ScreenCaptureJob job = new ScreenCaptureJob();
                // You can capture a window by setting its coordinates here
                job.CaptureRectangle = new Rectangle(100, 100, 200, 200);
                // Include the mouse pointer in the captured video
                job.CaptureMouseCursor = true;
                // Output file; you can transcode the xesc file to something else later.
                // Note that this silently does nothing if the file already exists.
                job.OutputScreenCaptureFileName = @"C:\Users\arx\scrcap\capture.xesc";
                // Do some capture
                job.Start();
                // Wait for a keypress
                Console.ReadKey();
                // And stop
                job.Stop();
            }
        }
    }
