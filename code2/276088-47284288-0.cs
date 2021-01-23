    using System;
    using System.Windows.Media;
    using SDColor = System.Drawing.Color;
    using SWMColor = System.Windows.Media.Color;
    using SWMBrush = System.Windows.Media.Brush;
    
    //Developed by امین امیری دربان
    namespace APREndUser.CodeAssist
    {
        public static class ColorHelper
        {
            public static SWMColor ToSWMColor(SDColor color) => SWMColor.FromArgb(color.A, color.R, color.G, color.B);
            public static SDColor ToSDColor(SWMColor color) => SDColor.FromArgb(color.A, color.R, color.G, color.B);
            public static SWMBrush ToSWMBrush(SDColor color) => (SolidColorBrush)(new BrushConverter().ConvertFrom(ToHexColor(color)));
            public static string ToHexColor(SDColor c) => "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            public static string ToRGBColor(SDColor c) => "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
            public static Tuple<SDColor, SDColor> GetColorFromRYGGradient(double percentage)
            {
                var red = (percentage > 50 ? 1 - 2 * (percentage - 50) / 100.0 : 1.0) * 255;
                var green = (percentage > 50 ? 1.0 : 2 * percentage / 100.0) * 255;
                var blue = 0.0;
                SDColor result1 = SDColor.FromArgb((int)red, (int)green, (int)blue);
                SDColor result2 = SDColor.FromArgb((int)green, (int)red, (int)blue);
                return new Tuple<SDColor, SDColor>(result1, result2);
            }
        }
    
    }
