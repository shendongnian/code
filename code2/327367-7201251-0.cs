    ...
    using System.Runtime.InteropServices;
    using System.Windows.Interop;
    namespace NoFlip3D
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            [DllImport("dwmapi.dll", PreserveSig = false)]
            public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
            [Flags]
            public enum DwmWindowAttribute
            {
                NCRenderingEnabled = 1,
                NCRenderingPolicy,
                TransitionsForceDisabled,
                AllowNCPaint,
                CaptionButtonBounds,
                NonClientRtlLayout,
                ForceIconicRepresentation,
                Flip3DPolicy,
                ExtendedFrameBounds,
                HasIconicBitmap,
                DisallowPeek,
                ExcludedFromPeek,
                Last
            }
    
            [Flags]
            public enum DwmNCRenderingPolicy
            {
                UseWindowStyle,
                Disabled,
                Enabled,
                Last
            }
            public MainWindow()
            {
                InitializeComponent();
            }
            public static void RemoveFromFlip3D(IntPtr Hwnd)
            {           
                int renderPolicy = (int)DwmNCRenderingPolicy.Enabled;
                DwmSetWindowAttribute(Hwnd, (int)DwmWindowAttribute.Flip3DPolicy, ref renderPolicy, sizeof(int));
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                IntPtr AppHandle = new WindowInteropHelper(this).Handle;
                RemoveFromFlip3D(AppHandle);
            }
        }
    }
