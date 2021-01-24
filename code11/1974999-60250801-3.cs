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
	Rectangle rect = ScreenResolutionHandler.GetRealRectangle(screen);
    int x = rect.X;
    int y = rect.Y;
    int w = rect.Width;
    int h = rect.Height;
	
    using (Bitmap bitmap = new Bitmap(w, h))
    {
        using (Graphics g = Graphics.FromImage(bitmap))
		{
		    g.CopyFromScreen(x,y, 0, 0, new Size(w, h));
		}
        bitmap.Save("screenshot.bmp");
    }
}
----------
**Update:**
As @Jimi suggested, eventually I had to enable per-monitor dpi-awareness to maintain the quality of the image when putting it on the Form
app.manifest
xml
<compatibility xmlns="urn:schemas-microsoft-com:compatibility.v1">
    <application>
		<!-- A list of the Windows versions that this application has been tested on
		   and is designed to work with. Uncomment the appropriate elements
		   and Windows will automatically select the most compatible environment. -->
		<!-- Windows Vista -->
		<!--<supportedOS Id="{e2011457-1546-43c5-a5fe-008deee3d3f0}" />-->
		<!-- Windows 7 -->
		<supportedOS Id="{35138b9a-5d96-4fbd-8e2d-a2440225f93a}" />
		<!-- Windows 8 -->
		<supportedOS Id="{4a2f28e3-53b9-4441-ba9c-d69d4a4a6e38}" />
		<!-- Windows 8.1 -->
		<supportedOS Id="{1f676c76-80e1-4239-95bb-83d0f6d0da78}" />
		<!-- Windows 10 -->
		<supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}" />
    </application>
</compatibility>
<application xmlns="urn:schemas-microsoft-com:asm.v3">
	<windowsSettings>
		<dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true/pm</dpiAware> <!-- legacy -->
		<dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">permonitorv2,permonitor</dpiAwareness> <!-- falls back to pm if pmv2 is not available -->
	</windowsSettings>
</application>
