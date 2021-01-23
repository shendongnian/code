	public partial class Form1 : Form
	{
		readonly Int32 ScrollBarWidth;
		readonly Int32 ScrollBarHeight;
		public Form1()
		{
			InitializeComponent();
			ScrollBarWidth	= GetSystemMetrics(SM_CYVSCROLL);
			ScrollBarHeight	= GetSystemMetrics(SM_CYHSCROLL);
		}
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Int32 ZoomMarkerSize = 6;
			Graphics G		= e.Graphics;
			Int32 SBWidth	= ScrollBarWidth;
			Int32 SBHeight	= ScrollBarHeight;
			DrawCustomScrollButton(G, 0, 0, SBWidth, SBHeight, Resources.Plus,
				(int) SCROLLBARSTYLESTATES.SCRBS_NORMAL);
			DrawCustomScrollButton(G, SBWidth, 0, ZoomMarkerSize, SBHeight, null,
				(int) SCROLLBARSTYLESTATES.SCRBS_NORMAL);
			DrawCustomScrollButton(G, SBWidth + ZoomMarkerSize, 0, SBWidth, SBHeight, Resources.Minus,
				(int) SCROLLBARSTYLESTATES.SCRBS_HOT);
		}
		public void DrawCustomScrollButton (Graphics aG, Int32 aX, Int32 aY, Int32 aWidth, Int32 aHeight,
			Image aImage, Int32 aState)
		{
			RECT R = new RECT () { left = aX, top = aY, right = aX + aWidth, bottom = aY + aHeight };
			RECT NotUsed = R;
			IntPtr ThemeHandle  = OpenThemeData(this.Handle, "SCROLLBAR");
			IntPtr HDC          = aG.GetHdc();
			DrawThemeBackground
			(
				ThemeHandle, HDC,
				(int) SCROLLBARPARTS.SBP_THUMBBTNHORZ,
				aState,
				ref R, ref NotUsed
			);
			aG.ReleaseHdc(HDC);
			CloseThemeData(ThemeHandle);
			if (aImage != null)
			{
				aG.DrawImage(aImage,
					aX + ((ScrollBarHeight - aImage.Width	) / 2),
					aY + ((ScrollBarHeight - aImage.Height	) / 2));
			}
		}
		public struct RECT
		{
			public Int32 left; 
			public Int32 top; 
			public Int32 right; 
			public Int32 bottom; 
		}
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(int smIndex);
		[DllImport("uxtheme.dll", ExactSpelling=true)]
		public extern static Int32 DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
		   int iStateId, ref RECT pRect, ref RECT pClipRect);
		[DllImport("uxtheme.dll", ExactSpelling=true, CharSet=CharSet.Unicode)]
		public static extern IntPtr OpenThemeData(IntPtr hWnd, String classList);
		[DllImport("uxtheme.dll", ExactSpelling=true)]
		public extern static Int32 CloseThemeData(IntPtr hTheme);
		public int SM_CYHSCROLL = 3;
		public int SM_CYVSCROLL = 20;
		public int SBP_ARROWBTN = 1;
		public int ABS_UPNORMAL = 1;
		public int ABS_UPHOT = 2;
		public int ABS_UPHOVER = 17;
		public enum ARROWBTNSTATES {
			ABS_UPNORMAL = 1,
			ABS_UPHOT = 2,
			ABS_UPPRESSED = 3,
			ABS_UPDISABLED = 4,
			ABS_DOWNNORMAL = 5,
			ABS_DOWNHOT = 6,
			ABS_DOWNPRESSED = 7,
			ABS_DOWNDISABLED = 8,
			ABS_LEFTNORMAL = 9,
			ABS_LEFTHOT = 10,
			ABS_LEFTPRESSED = 11,
			ABS_LEFTDISABLED = 12,
			ABS_RIGHTNORMAL = 13,
			ABS_RIGHTHOT = 14,
			ABS_RIGHTPRESSED = 15,
			ABS_RIGHTDISABLED = 16,
			ABS_UPHOVER = 17,
			ABS_DOWNHOVER = 18,
			ABS_LEFTHOVER = 19,
			ABS_RIGHTHOVER = 20,
		};
		public enum SCROLLBARSTYLESTATES {
			SCRBS_NORMAL = 1,
			SCRBS_HOT = 2,
			SCRBS_PRESSED = 3,
			SCRBS_DISABLED = 4,
			SCRBS_HOVER = 5,
		};
		public enum SCROLLBARPARTS {
			SBP_ARROWBTN = 1,
			SBP_THUMBBTNHORZ = 2,
			SBP_THUMBBTNVERT = 3,
			SBP_LOWERTRACKHORZ = 4,
			SBP_UPPERTRACKHORZ = 5,
			SBP_LOWERTRACKVERT = 6,
			SBP_UPPERTRACKVERT = 7,
			SBP_GRIPPERHORZ = 8,
			SBP_GRIPPERVERT = 9,
			SBP_SIZEBOX = 10,
		};
	}
