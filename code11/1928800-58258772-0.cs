    public class Graphics
    {
        public Graphics(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
            Construct();
        }
        public string Name { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Script { get; private set; }
        void Construct()
        {
            Script = "";
            Script += "var c" + Name + " = document.getElementById(\"canvas" + Name + "\");\n";
            Script += "var ctx" + Name + " = c" + Name + ".getContext(\"2d\");\n";
        }
        public void FillRectangle(SolidBrush brush, Rectangle rect)
        {
            FillRectangle(brush, rect.Left, rect.Top, rect.Width, rect.Height);
        }
        public void FillRectangle(SolidBrush brush, int x, int y, int width, int height)
        {
            Script += "ctx" + Name + ".fillStyle = \"" + brush.Color.ToRgbaCode() + "\";\n";
            Script += "ctx" + Name + ".fillRect(" + x + ", " + y + ", " + width + ", " + height + ");\n";
        }
        internal void DrawLine(Pen pen, Point point1, Point point2)
        {
            DrawLine(pen, point1.X, point1.Y, point2.X, point2.Y);
        }
        public void DrawLine(Pen pen, int x, int y, int x2, int y2)
        {
            Script += "ctx" + Name + ".beginPath();";
            Script += "ctx" + Name + ".strokeStyle = \"" + pen.Color.ToRgbaCode() + "\";\n";
            Script += "ctx" + Name + ".lineWidth = \"" + pen.Width + "\";\n";
            Script += "ctx" + Name + ".moveTo(" + x + ", " + y + ");\n";
            Script += "ctx" + Name + ".lineTo(" + x2 + ", " + y2 + ");\n";
            Script += "ctx" + Name + ".stroke();\n";
            Script += "ctx" + Name + ".closePath();\n";
        }
        public void DrawArrow(Pen pen, int x, int y, int x2, int y2)
        {
            var headlen = 32; // length of head in pixels
            var dx = x2 - x;
            var dy = y2 - y;
            var angle = Math.Atan2(dy, dx);
            Script += "ctx" + Name + ".beginPath();";
            Script += "ctx" + Name + ".strokeStyle = \"" + pen.Color.ToRgbaCode() + "\";\n";
            Script += "ctx" + Name + ".lineWidth = \"" + pen.Width + "\";\n";
            Script += "ctx" + Name + ".moveTo(" + x.ToString("F0") + ", " + y.ToString("F0") + ");\n";
            Script += "ctx" + Name + ".lineTo(" + x2.ToString("F0") + ", " + y2.ToString("F0") + ");\n";
            Script += "ctx" + Name + ".lineTo(" + (x2 - headlen * Math.Cos(angle - Math.PI / 6)).ToString("F0") + ", " + (y2 - headlen * Math.Sin(angle - Math.PI / 6)).ToString("F0") + ");\n";
            Script += "ctx" + Name + ".moveTo(" + x2.ToString("F0") + ", " + y2.ToString("F0") + ");\n";
            Script += "ctx" + Name + ".lineTo(" + (x2 - headlen * Math.Cos(angle + Math.PI / 6)).ToString("F0") + ", " + (y2 - headlen * Math.Sin(angle + Math.PI / 6)).ToString("F0") + ");\n";
            Script += "ctx" + Name + ".stroke();\n";
            Script += "ctx" + Name + ".closePath();\n";
        }
        public void DrawString(string text, Font font, SolidBrush color, Rectangle rectangle, StringFormat format)
        {
            var topoffset = 0;
            if (format.LineAlignment == StringAlignment.Far)
            {
                topoffset = rectangle.Height;
            }
            else if (format.LineAlignment == StringAlignment.Center)
            {
                topoffset = (rectangle.Height - font.Size) / 2 + font.Size;
            }
            else
            {
                topoffset = font.Size;
            }
            Script += "ctx" + Name + ".font = \"" + font.Size + "px " + font.FontFamily.Name + "\";\n";
            Script += "ctx" + Name + ".fillStyle = \"" + color.Color.ToRgbaCode() + "\";\n";
            //if (format.FormatFlags == StringFormatFlags.DirectionVertical)
            //{
            //    Script += "ctx" + Name + ".rotate(90 * Math.PI / 180);\n";
            //}
            if (format.Alignment == StringAlignment.Far)
            {
                // Horizontal Right
                var left = rectangle.Left + rectangle.Width;
                var top = rectangle.Top + topoffset;
                Script += "ctx" + Name + ".textAlign = \"right\";\n";
                Script += "ctx" + Name + ".fillText(\"" + text + "\", \"" + left + "\", \"" + top + "\");\n";
            }
            else if (format.Alignment == StringAlignment.Center)
            {
                // Horizontal Center
                var left = rectangle.Left + rectangle.Width / 2;
                var top = rectangle.Top + topoffset;
                Script += "ctx" + Name + ".textAlign = \"center\";\n";
                Script += "ctx" + Name + ".fillText(\"" + text + "\", \"" + left + "\", \"" + top + "\");\n";
            }
            else
            {
                // Horizontal Left
                var left = rectangle.Left;
                var top = rectangle.Top + topoffset;
                Script += "ctx" + Name + ".textAlign = \"left\";\n";
                Script += "ctx" + Name + ".fillText(\"" + text + "\", \"" + left + "\", \"" + top + "\");\n";
            }
            //if (format.FormatFlags == StringFormatFlags.DirectionVertical)
            //{
            //    Script += "ctx" + Name + ".rotate(0);\n";
            //}
        }
        public void DrawRectangle(Pen pen, Rectangle rect)
        {
            Script += "ctx" + Name + ".beginPath();\n";
            Script += "ctx" + Name + ".lineWidth = \"" + pen.Width + "\";\n";
            Script += "ctx" + Name + ".strokeStyle = \"" + pen.Color.ToRgbaCode() + "\";\n";
            Script += "ctx" + Name + ".rect(" + rect.Left + ", " + rect.Top + ", " + rect.Width + ", " + rect.Height + ");\n";
            Script += "ctx" + Name + ".stroke();\n";
        }
        public void DrawEllipse(Pen pen, double x, double y, double w, double h)
        {
            Script += "ctx" + Name + ".beginPath();\n";
            var kappa = .5522848;
            var ox = (w / 2) * kappa; // control point offset horizontal
            var oy = (h / 2) * kappa; // control point offset vertical
            var xe = x + w;           // x-end
            var ye = y + h;           // y-end
            var xm = x + w / 2;       // x-middle
            var ym = y + h / 2;       // y-middle
            Script += "ctx" + Name + ".beginPath();";
            Script += "ctx" + Name + ".strokeStyle = \"" + pen.Color.ToRgbaCode() + "\";\n";
            Script += "ctx" + Name + ".lineWidth = \"" + pen.Width + "\";\n";
            Script += "ctx" + Name + ".moveTo(" + x + ", " + ym + ");";
            Script += "ctx" + Name + ".bezierCurveTo(" + x + ", " + (ym - oy) + ", " + (xm - ox) + ", " + y + ", " + xm + ", " + y + ");";
            Script += "ctx" + Name + ".bezierCurveTo(" + (xm + ox) + ", " + y + ", " + xe + ", " + (ym - oy) + ", " + xe + ", " + ym + ");";
            Script += "ctx" + Name + ".bezierCurveTo(" + xe + ", " + (ym + oy) + ", " + (xm + ox) + ", " + ye + ", " + xm + ", " + ye + ");";
            Script += "ctx" + Name + ".bezierCurveTo(" + (xm - ox) + ", " + ye + ", " + x + ", " + (ym + oy) + ", " + x + ", " + ym + ");";
            Script += "ctx" + Name + ".lineWidth = \"" + pen.Width + "\";\n";
            Script += "ctx" + Name + ".strokeStyle = \"" + pen.Color.ToRgbaCode() + "\";\n";
            Script += "ctx" + Name + ".stroke();\n";
            Script += "ctx" + Name + ".closePath();\n";
        }
        public void FillEllipse(SolidBrush brush, double x, double y, double w, double h)
        {
            Script += "ctx" + Name + ".beginPath();\n";
            var kappa = .5522848;
            var ox = (w / 2) * kappa; // control point offset horizontal
            var oy = (h / 2) * kappa; // control point offset vertical
            var xe = x + w;           // x-end
            var ye = y + h;           // y-end
            var xm = x + w / 2;       // x-middle
            var ym = y + h / 2;       // y-middle
            Script += "ctx" + Name + ".beginPath();";
            Script += "ctx" + Name + ".fillStyle = \"" + brush.Color.ToRgbaCode() + "\";\n";
            Script += "ctx" + Name + ".moveTo(" + x + ", " + ym + ");";
            Script += "ctx" + Name + ".bezierCurveTo(" + x +            ", " + (ym - oy) +  ", " + (xm - ox) +  ", " + y +          ", " + xm +     ", " + y + ");";
            Script += "ctx" + Name + ".bezierCurveTo(" + (xm + ox) +    ", " + y +          ", " + xe +         ", " + (ym - oy) +  ", " + xe +     ", " + ym + ");";
            Script += "ctx" + Name + ".bezierCurveTo(" + xe +           ", " + (ym + oy) +  ", " + (xm + ox) +  ", " + ye +         ", " + xm +     ", " + ye + ");";
            Script += "ctx" + Name + ".bezierCurveTo("+ (xm - ox) +     ", " + ye +         ", " + x +          ", " + (ym + oy) +  ", " + x +      ", " + ym + ");";
            Script += "ctx" + Name + ".fill();\n";
            Script += "ctx" + Name + ".closePath();\n";
        }
        public void DrawImage(Image img, Rectangle rectangle)
        {
            Script += "var img" + img.Id + " = new Image;\n";
            Script += "ctx" + Name + ".onload = function() {\n";
            Script += "   ctx" + Name + ".drawImage(img" + img.Id + ", 0, 0);\n";
            Script += "};\n";
            Script += "img" + img.Id + ".src = \"" + img.Url + "\";\n";
        }
    }
    public static class Brushes
    {
        public static SolidBrush Black => new SolidBrush(Color.Black);
        public static SolidBrush White => new SolidBrush(Color.White);
    }
    public class Color
    {
        public Color(int a, int r, int g, int b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }
        public int A { get; private set; }
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }
        public static Color FromArgb(int r, int g, int b)
        {
            return new Color(255, r, g, b);
        }
        public string ToRgbaCode() => "rgba(" + R + ", " + G + ", " + B + ", " + A + ")";
        public static Color LightGray => new Color(255, 192, 192, 192);
        public static Color White => new Color(255, 255, 255, 255);
        public static Color Black => new Color(255, 0, 0, 0);
        public static Color LightBlue => new Color(255, 128, 128, 255);
        public static Color DarkBlue => new Color(255, 0, 0, 128);
        public static Color Gray => new Color(255, 128, 128, 128);
        public static Color Green => new Color(255, 0, 255, 0);
    }
    public class Font : IDisposable
    {
        public Font(FontFamily fontFamily, int largefont, FontStyle regular)
        {
            this.FontFamily = fontFamily;
            this.Size = largefont;
            this.FontStyle = regular;
        }
        public FontFamily FontFamily { get; set; }
        public int Size { get; set; }
        public FontStyle FontStyle { get; set; }
        public void Dispose()
        {
        }
    }
    public class FontFamily : IDisposable
    {
        public FontFamily(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        public void Dispose()
        {
        }
    }
    public enum FontStyle
    {
        Regular
    }
    public class Image : IDisposable
    {
        static long _Id { get; set; }
        public long Id { get; } = ++_Id;
        public Image(string url)
        {
            this.Url = url;
        }
        public string Url { get; set; }
        public static Image FromFile(string url)
        {
            return new Image(url);
        }
        public void Dispose()
        {
        }
    }
    public class Pen : IDisposable
    {
        public Pen(SolidBrush black)
        {
            this.Brush = black;
        }
        public Pen(Color color, int width)
        {
            this.Brush = new SolidBrush(color, width);
        }
        public SolidBrush Brush { get; private set; }
        public Color Color => Brush.Color;
        public int Width => Brush.Width;
        public float[] DashPattern { get; internal set; }
        public void Dispose()
        {
        }
    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    public class Rectangle
    {
        public Rectangle()
        {
        }
        public Rectangle(int left, int top, int width, int height)
        {
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
        }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Right => Left + Width;
        public int Bottom => Top + Height;
    }
    public class SolidBrush : IDisposable
    {
        public SolidBrush(Color color, int width = 1)
        {
            this.Color = color;
            this.Width = width;
        }
        public Color Color { get; set; }
        public int Width { get; set; }
        public void Dispose()
        {
        }
    }
    public enum StringAlignment
    {
        Near,
        Center,
        Far
    }
    public class StringFormat : IDisposable
    {
        public StringAlignment LineAlignment { get; set; } = StringAlignment.Near;
        public StringAlignment Alignment { get; set; } = StringAlignment.Near;
        public StringFormatFlags FormatFlags { get; set; } = StringFormatFlags.DirectionHorizontal;
        public void Dispose()
        {
        }
    }
    public enum StringFormatFlags
    {
        DirectionHorizontal,
        DirectionVertical
    }
