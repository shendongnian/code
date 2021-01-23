    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    
    namespace CRT
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public class NativeMethods
    
            {
                [DllImport("user32.dll", EntryPoint = "MonitorFromWindow", SetLastError = true)]
                public static extern IntPtr MonitorFromWindow(
                    [In] IntPtr hwnd, uint dwFlags);
    
                [DllImport("dxva2.dll", EntryPoint = "GetNumberOfPhysicalMonitorsFromHMONITOR", SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(
                    IntPtr hMonitor, ref uint pdwNumberOfPhysicalMonitors);
    
                [DllImport("dxva2.dll", EntryPoint = "GetPhysicalMonitorsFromHMONITOR", SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool GetPhysicalMonitorsFromHMONITOR(
                    IntPtr hMonitor,
                    uint dwPhysicalMonitorArraySize,
                    [Out] NativeStructures.PHYSICAL_MONITOR[] pPhysicalMonitorArray);
    
                [DllImport("dxva2.dll", EntryPoint = "DestroyPhysicalMonitors", SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool DestroyPhysicalMonitors(
                    uint dwPhysicalMonitorArraySize, [Out] NativeStructures.PHYSICAL_MONITOR[] pPhysicalMonitorArray);
    
                [DllImport("dxva2.dll", EntryPoint = "GetMonitorTechnologyType", SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool GetMonitorTechnologyType(
                    IntPtr hMonitor, ref NativeStructures.MC_DISPLAY_TECHNOLOGY_TYPE pdtyDisplayTechnologyType);
    
                [DllImport("dxva2.dll", EntryPoint = "GetMonitorCapabilities", SetLastError = true)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool GetMonitorCapabilities(
                    IntPtr hMonitor, ref uint pdwMonitorCapabilities, ref uint pdwSupportedColorTemperatures);
            }
    
            public class NativeConstants
            {
                public const int MONITOR_DEFAULTTOPRIMARY = 1;
    
                public const int MONITOR_DEFAULTTONEAREST = 2;
    
                public const int MONITOR_DEFAULTTONULL = 0;
            }
    
            public class NativeStructures
            {
                [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
                public struct PHYSICAL_MONITOR
                {
                    public IntPtr hPhysicalMonitor;
    
                    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)] public string szPhysicalMonitorDescription;
                }
    
                public enum MC_DISPLAY_TECHNOLOGY_TYPE
                {
                    MC_SHADOW_MASK_CATHODE_RAY_TUBE,
    
                    MC_APERTURE_GRILL_CATHODE_RAY_TUBE,
    
                    MC_THIN_FILM_TRANSISTOR,
    
                    MC_LIQUID_CRYSTAL_ON_SILICON,
    
                    MC_PLASMA,
    
                    MC_ORGANIC_LIGHT_EMITTING_DIODE,
    
                    MC_ELECTROLUMINESCENT,
    
                    MC_MICROELECTROMECHANICAL,
    
                    MC_FIELD_EMISSION_DEVICE,
                }
            }
    
            public Window1() { InitializeComponent(); }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                WindowInteropHelper helper = new WindowInteropHelper(this);
    
                IntPtr hMonitor = NativeMethods.MonitorFromWindow(helper.Handle, NativeConstants.MONITOR_DEFAULTTOPRIMARY);
                int lastWin32Error = Marshal.GetLastWin32Error();
    
                uint pdwNumberOfPhysicalMonitors = 0u;
                bool numberOfPhysicalMonitorsFromHmonitor = NativeMethods.GetNumberOfPhysicalMonitorsFromHMONITOR(
                    hMonitor, ref pdwNumberOfPhysicalMonitors);
                lastWin32Error = Marshal.GetLastWin32Error();
    
                NativeStructures.PHYSICAL_MONITOR[] pPhysicalMonitorArray =
                    new NativeStructures.PHYSICAL_MONITOR[pdwNumberOfPhysicalMonitors];
                bool physicalMonitorsFromHmonitor = NativeMethods.GetPhysicalMonitorsFromHMONITOR(
                    hMonitor, pdwNumberOfPhysicalMonitors, pPhysicalMonitorArray);
                lastWin32Error = Marshal.GetLastWin32Error();
    
                uint pdwMonitorCapabilities = 0u;
                uint pdwSupportedColorTemperatures = 0u;
                var monitorCapabilities = NativeMethods.GetMonitorCapabilities(
                    pPhysicalMonitorArray[0].hPhysicalMonitor, ref pdwMonitorCapabilities, ref pdwSupportedColorTemperatures);
                lastWin32Error = Marshal.GetLastWin32Error();
    
                NativeStructures.MC_DISPLAY_TECHNOLOGY_TYPE type =
                    NativeStructures.MC_DISPLAY_TECHNOLOGY_TYPE.MC_SHADOW_MASK_CATHODE_RAY_TUBE;
                var monitorTechnologyType = NativeMethods.GetMonitorTechnologyType(
                    pPhysicalMonitorArray[0].hPhysicalMonitor, ref type);
                lastWin32Error = Marshal.GetLastWin32Error();
    
                var destroyPhysicalMonitors = NativeMethods.DestroyPhysicalMonitors(
                    pdwNumberOfPhysicalMonitors, pPhysicalMonitorArray);
                lastWin32Error = Marshal.GetLastWin32Error();
    
                this.lbl.Content = type;
            }
        }
    }
