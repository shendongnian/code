    using System.Drawing;
    ...
            public static Color GetDwmColorizationColor() {
                using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\DWM")) {
                    return Color.FromArgb((int)key.GetValue("ColorizationColor"));
                }
            }
