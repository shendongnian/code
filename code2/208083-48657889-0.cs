    using System; 
    using System.Collections.Generic; 
    using System.ComponentModel; 
    using System.Data; 
    using System.Drawing; 
    using System.Linq; 
    using System.Text; 
    using System.Threading.Tasks; 
    using System.Windows.Forms; 
    using System.Runtime.InteropServices; 
    namespace brightnesscontrol 
    { 
       public partial class Form1 : Form 
       { 
           [DllImport("gdi32.dll")] 
           private unsafe static extern bool SetDeviceGammaRamp(Int32 hdc, void* ramp); 
           private static bool initialized = false; 
           private static Int32 hdc; 
           private static int a; 
           public Form1() 
           { 
               InitializeComponent(); 
           } 
           private static void InitializeClass() 
           { 
               if (initialized) 
                   return; 
               hdc = Graphics.FromHwnd(IntPtr.Zero).GetHdc().ToInt32(); 
               initialized = true; 
           } 
           public static unsafe bool SetBrightness(int brightness) 
           { 
               InitializeClass(); 
               if (brightness > 255) 
                   brightness = 255; 
               if (brightness < 0) 
                   brightness = 0; 
               short* gArray = stackalloc short[3 * 256]; 
               short* idx = gArray; 
               for (int j = 0; j < 3; j++) 
               { 
                   for (int i = 0; i < 256; i++) 
                   { 
                       int arrayVal = i * (brightness + 128); 
                       if (arrayVal > 65535) 
                           arrayVal = 65535; 
                       *idx = (short)arrayVal; 
                       idx++; 
                   } 
               } 
               bool retVal = SetDeviceGammaRamp(hdc, gArray); 
               return retVal; 
           } 
           private void trackBar1_Scroll(object sender, EventArgs e) 
           { 
           } 
           private void button1_Click(object sender, EventArgs e) 
           { 
               a = trackBar1.Value; 
               SetBrightness(a); 
           } 
       } 
    } 
