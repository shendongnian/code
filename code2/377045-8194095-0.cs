    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    
    namespace MediaManagerSql.DataAccess.Sql.EntityFramework
    {
        public class ScreenBrightness : Component
        {
            private int _gammaValue;
            private RAMP _ramp;
    
            public ScreenBrightness()
            {
                InitializeComponent();
            }
    
            public ScreenBrightness(IContainer container)
            {
                container.Add(this);
                InitializeComponent();
            }
    
            [Description("Brightness Gamma Value")]
            [Category("Brightness")]
            public int SetGammaValue
            {
                get { return _gammaValue; }
                set { _gammaValue = value; }
            }
    
            [DllImport("gdi32.dll")]
            public static extern bool SetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);
            [DllImport("user32.dll")]
            private static extern IntPtr GetDC(IntPtr hWnd);
    
            /// <summary>
            /// Apply the selected gamma value to screen
            /// </summary>
            public void ApplyGamma()
            {
                // since gamma value is max 44 ,, we need to take the percentage from this because 
                // it needed from 0 - 100%
                double gValue = _gammaValue;
                gValue = Math.Floor(Convert.ToDouble((gValue/2.27)));
    
                _gammaValue = Convert.ToInt16(gValue);
    
                if (_gammaValue != 0)
                {
                    _ramp.Red = new ushort[256];
                    _ramp.Green = new ushort[256];
                    _ramp.Blue = new ushort[256];
    
                    for (int i = 1; i < 256; i++)
                    {
                        // gamma is a value between 3 and 44
                        _ramp.Red[i] =
                            _ramp.Green[i] =
                            _ramp.Blue[i] =
                            (ushort)
                            (Math.Min(65535, Math.Max(0, Math.Pow((i + 1)/256.0, (_gammaValue + 5)*0.1)*65535 + 0.5)));
                    }
    
                    SetDeviceGammaRamp(GetDC(IntPtr.Zero), ref _ramp);
                }
            }
    
            #region Nested type: RAMP
    
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct RAMP
            {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] public UInt16[] Red;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] public UInt16[] Green;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] public UInt16[] Blue;
            }
            #endregion
        }
    }
