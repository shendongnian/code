    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Threading;
    using System.Diagnostics;
    
    namespace ScreenRecorder
    {
        class Program
        {
            private static System.Timers.Timer screenTimer;
            private static int screenNumber;
            private static Mutex m = new Mutex();
    
            static void Main(string[] args)
            {
                screenTimer = new System.Timers.Timer(40);
    
                // Hook up the Elapsed event for the timer.
                screenTimer.Elapsed += new System.Timers.ElapsedEventHandler(screenTimer_Elapsed);
                screenTimer.Enabled = true;
    
                Console.Read();
            }
    
    
            static void screenTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Thread t = new Thread(()=>SaveImage());
                t.Start();
            }
    
            private static void SaveImage()
            {
                m.WaitOne();
                Image myImage = CaptureScreen();
                myImage.Save(@"C:\stuff\Development\ScreenRecorder\ScreenImages\img" + screenNumber + ".png");
                myImage.Dispose();
                screenNumber++;
                m.ReleaseMutex();
            }
    
            private static Image CaptureScreen()
            {
                Rectangle screenSize = Screen.PrimaryScreen.Bounds;
                Bitmap target = new Bitmap(screenSize.Width, screenSize.Height);
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.CopyFromScreen(0, 0, 0, 0, new Size(screenSize.Width, screenSize.Height));
                }
                return target;
            }
        }
    }
