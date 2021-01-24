cs
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace ScreenResolution
{
    class ScreenResolutionHandler
    {
        const int ENUM_CURRENT_SETTINGS = -1;
        public static Rectangle GetRealRectangle(Screen screen)
        {
            DEVMODE dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            EnumDisplaySettings(screen.DeviceName, ENUM_CURRENT_SETTINGS, ref dm);
            return new Rectangle(dm.dmPositionX, dm.dmPositionY, dm.dmPelsWidth, dm.dmPelsHeight);
        }
        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }
    }
}
and editing the original code to
cs
public void SaveScreenshot(Screen screen)
{
	int x = ScreenResolutionHandler.GetRealRectangle(screen).X;
	int y = ScreenResolutionHandler.GetRealRectangle(screen).Y;
	int w = ScreenResolutionHandler.GetRealRectangle(screen).Width;
	int h = ScreenResolutionHandler.GetRealRectangle(screen).Height;
	
    using (Bitmap bitmap = new Bitmap(w, h))
    {
        using (Graphics g = Graphics.FromImage(bitmap))
		{
		    g.CopyFromScreen(x,y, 0, 0, new Size(w, h));
		}
        bitmap.Save("screenshot.bmp");
    }
}
