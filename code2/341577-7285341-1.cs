    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    
    namespace PE.Rendering {
    
        static class FontHelper {
    
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            class LOGFONT {
                public int lfHeight;
                public int lfWidth;
                public int lfEscapement;
                public int lfOrientation;
                public int lfWeight;
                public byte lfItalic;
                public byte lfUnderline;
                public byte lfStrikeOut;
                public byte lfCharSet;
                public byte lfOutPrecision;
                public byte lfClipPrecision;
                public byte lfQuality;
                public byte lfPitchAndFamily;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string lfFaceName;
            }
    
            static bool IsMonospaced(Graphics g, Font f)
            {
                float w1, w2;
    
                    w1 = g.MeasureString("i", f).Width;
                    w2 = g.MeasureString("W", f).Width;
                    return w1 == w2;
            }
    
            static bool IsSymbolFont(Font font)
            {
                const byte SYMBOL_FONT = 2;
    
                LOGFONT logicalFont = new LOGFONT();
                font.ToLogFont(logicalFont);
                return logicalFont.lfCharSet == SYMBOL_FONT;
            }
    
            /// <summary>
            /// Tells us, if a font is suitable for displaying document.
            /// </summary>
            /// <remarks>Some symbol fonts do not identify themselves as such.</remarks>
            /// <param name="fontName"></param>
            /// <returns></returns>
            static bool IsSuitableFont(string fontName)
            {
                return !fontName.StartsWith("ESRI") && !fontName.StartsWith("Oc_");
            }
    
            public static List<string> GetMonospacedFontNames()
            {
                List<string> fontList = new List<string>();
                InstalledFontCollection ifc;
    
                ifc = new InstalledFontCollection();
                using (Bitmap bmp = new Bitmap(1, 1)) {
                    using (Graphics g = Graphics.FromImage(bmp)) {
                        foreach (FontFamily ff in ifc.Families) {
                            if (ff.IsStyleAvailable(FontStyle.Regular) && ff.IsStyleAvailable(FontStyle.Bold) 
                                && ff.IsStyleAvailable(FontStyle.Italic) && IsSuitableFont( ff.Name)) {
                                using (Font f = new Font(ff, 10)) {
                                    if (IsMonospaced(g,f) && !IsSymbolFont(f)) {
                                        fontList.Add(ff.Name);
                                    }
                                }
                            }
                        }
                    }
                }
                return fontList;
            }
        }
    
    }
