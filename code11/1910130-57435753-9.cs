    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows;
    namespace McveMultipleScreensWpf
    {
        public partial class MainWindow
        {
            public MainWindow() => InitializeComponent();
            private readonly List<Window> identifierWindows = new List<Window>();
            private void ShowWindows()
            {
                foreach (Monitor monitor in MonitorUtility.GetMonitors())
                {
                    Point point = monitor.WpfCoordinateRelativeToTopLeft(10, 10);
                    Window tempWindow = new IdentityWindow
                    {
                        Left = point.X,
                        Top = point.Y,
                        Owner = this
                    };
                    tempWindow.Show();
                    identifierWindows.Add(tempWindow);
                }
            }
            private void CloseWindows()
            {
                foreach (Window window in identifierWindows)
                {
                    window.Close();
                }
                identifierWindows.Clear();
            }
            private void Show_Click(object sender, RoutedEventArgs e) => ShowWindows();
            private void Hide_Click(object sender, RoutedEventArgs e) => CloseWindows();
        }
        #region Code required to work out monitor size and position
        internal static class MonitorUtility
        {
            private delegate bool MonitorEnumDelegate(IntPtr monitorHandle,
                IntPtr displayDeviceContextHandle,
                ref Rect monitorSize,
                IntPtr callbackData);
            [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern bool EnumDisplayMonitors(IntPtr displayDeviceContextHandle,
                IntPtr clipArea,
                MonitorEnumDelegate callback,
                IntPtr callbackData);
            [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern bool GetMonitorInfo(IntPtr hMonitor,
                ref MonitorInformationStruct monitorInformationStruct);
            [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern bool EnumDisplaySettings(string deviceName,
                int modeNum,
                ref DeviceModeStruct deviceMode);
            internal static IEnumerable<Monitor> GetMonitors()
            {
                List<Monitor> monitors = new List<Monitor>();
                EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, delegate (IntPtr monitorHandle, IntPtr displayDeviceContextHandle, ref Rect monitorSize, IntPtr callbackData)
                {
                    MonitorInformationStruct monitorInfo = new MonitorInformationStruct();
                    // Has to be set before it is used so GetMonitorInfo knows what it is dealing with
                    monitorInfo.Size = Marshal.SizeOf(monitorInfo);
                    GetMonitorInfo(monitorHandle, ref monitorInfo);
                    DeviceModeStruct deviceMode = new DeviceModeStruct();
                    EnumDisplaySettings(monitorInfo.DeviceName, -1, ref deviceMode);
                    monitors.Add(new Monitor(monitorInfo, deviceMode));
                    return true;
                }, IntPtr.Zero);
                return monitors;
            }
        }
        internal class Monitor
        {
            private readonly DeviceModeStruct deviceMode;
            private readonly double dpiScale;
            internal Monitor(MonitorInformationStruct monitorInfo,
                DeviceModeStruct deviceMode)
            {
                this.deviceMode = deviceMode;
                dpiScale = (double)deviceMode.dmPelsWidth /
                           (monitorInfo.Monitor.Right - monitorInfo.Monitor.Left) *
                           ((int)typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null) / 96.0);
            }
            internal Point WpfCoordinateRelativeToTopLeft(double xCoordinate, double yCoordinate)
            {
                return new Point(xCoordinate + deviceMode.fields.Position.x / dpiScale,
                    yCoordinate + deviceMode.fields.Position.y / dpiScale);
            }
        }
        #endregion
        #region Code needed for C++ methods
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct MonitorInformationStruct
        {
            private const int DEVICE_NAME_MAX_SIZE = 32;
            internal int Size;
            internal RectangleStruct Monitor;
            internal RectangleStruct WorkArea;
            internal int IsPrimaryMonitor;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DEVICE_NAME_MAX_SIZE)]
            internal string DeviceName;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct RectangleStruct
        {
            internal int Left;
            internal int Top;
            internal int Right;
            internal int Bottom;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct DeviceModeStruct
        {
            private const int STRING_SIZE = 32;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_SIZE)]
            internal string dmDeviceName;
            internal ushort dmSpecVersion;
            internal ushort dmDriverVersion;
            internal ushort dmSize;
            internal ushort dmDriverExtra;
            internal uint dmFields;
            internal DeviceModeUnionOne fields;
            internal short dmColor;
            internal short dmDuplex;
            internal short dmYResolution;
            internal short dmTTOption;
            internal short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STRING_SIZE)]
            internal string dmFormName;
            internal ushort dmLogPixels;
            internal uint dmBitsPerPel;
            internal uint dmPelsWidth;
            internal uint dmPelsHeight;
            internal DeviceModeUnionTwo FlagsNup;
            internal uint dmDisplayFrequency;
            internal uint dmICMMethod;
            internal uint dmICMIntent;
            internal uint dmMediaType;
            internal uint dmDitherType;
            internal uint dmReserved1;
            internal uint dmReserved2;
            internal uint dmPanningWidth;
            internal uint dmPanningHeight;
        }
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
        internal struct DeviceModeUnionOne
        {
            [FieldOffset(0)] internal PrinterOnlyFields Printer;
            [FieldOffset(0)] internal PointStruct Position;
            [FieldOffset(0)] internal DisplayOnlyFields Display;
        }
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
        internal struct DeviceModeUnionTwo
        {
            [FieldOffset(0)] internal uint dmDisplayFlags;
            [FieldOffset(0)] internal uint dmNup;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct PrinterOnlyFields
        {
            internal short dmOrientation;
            internal short dmPaperSize;
            internal short dmPaperLength;
            internal short dmPaperWidth;
            internal short dmScale;
            internal short dmCopies;
            internal short dmDefaultSource;
            internal short dmPrintQuality;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct PointStruct
        {
            internal int x;
            internal int y;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct DisplayOnlyFields
        {
            internal PointStruct dmPosition;
            internal uint dmDisplayOrientation;
            internal uint dmDisplayFixedOutput;
        }
        #endregion
    }
