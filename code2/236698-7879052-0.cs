    public static class LFTheme 
        {
            const int ThemeClassic = 0;
            const int ThemeBlue = 1;
            const int ThemeSilver = 2;
            const int ThemeBlack = 3;
    
            public static int Theme { get; set; }
            public static Color BackColor { get; set; }
            public static Color ForeColor { get; set; }
            public static Color ForeColorLight { get; set; }
            public static Color ForeColorDark { get; set; }
            public static Color TextColor { get; set; }
            public static System.Drawing.Font Font { get; set; }
    
            public static Excel.Application ExcelApp { get; set; }
            public static Double ExcelVersion { get; set; }
            
            static LFTheme()
            {
                InitLook();
            }
    
    
         public static void InitLook()
                {
                    const string OfficeCommonKey = @"Software\Microsoft\Office\{0:0.0}\Common";
                    const string OfficeThemeValueName = "Theme";
        
                    Theme = 0;
                    BackColor = System.Windows.Forms.Control.DefaultBackColor;
                    ForeColor = System.Drawing.SystemColors.Control;
                    ForeColorLight = System.Drawing.SystemColors.ControlLight;
                    ForeColorDark = System.Drawing.SystemColors.ControlDark;
                    TextColor = System.Drawing.SystemColors.ControlText;
                    Font = System.Windows.Forms.Control.DefaultFont;
        
                    if (ExcelVersion<12.0)
                        return;
        
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(String.Format(OfficeCommonKey, ExcelVersion), false))
                    {
                        try
                        {
                            Theme = (int)key.GetValue(OfficeThemeValueName);
                        }
                        catch (Exception ex)
                        {
                            Theme = ThemeClassic;
                            if (ExcelVersion >= 12.0)
                            {
                                Theme = ThemeBlue;
                            }
                        }
        
                        switch (Theme)
                        {
                            case ThemeBlue:
                                BackColor = Color.FromArgb(255, 213, 228, 242);
                                ForeColor = Color.FromArgb(255, 107, 160, 209);
                                ForeColorLight = Color.FromArgb(255, 185, 210, 234);
                                ForeColorDark = Color.FromArgb(255, 87, 149, 204);
                                TextColor = Color.FromArgb(255, 50, 108, 160);
                                Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                                break;
        
                            case ThemeSilver:
                                BackColor = Color.FromArgb(255, 232, 236, 243);
                                ForeColor = Color.FromArgb(255, 158, 162, 161);
                                ForeColorLight = Color.FromArgb(255, 200, 206, 205);
                                ForeColorDark = Color.FromArgb(255, 128, 133, 131);
                                TextColor = Color.FromArgb(255, 116, 118, 123);
                                Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                                break;
        
                            case ThemeBlack:
                                BackColor = Color.FromArgb(255, 83, 83, 83);
                                ForeColor = Color.FromArgb(255, 168, 170, 170);
                                ForeColorLight = Color.FromArgb(255, 188, 190, 190);
                                ForeColorDark = Color.FromArgb(255, 148, 150, 150);
                                TextColor = Color.FromArgb(255, 224, 226, 226);
                                Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                                break;
        
                            default:                    
                                break;
                        }
                    }
                }
    
    
    }
