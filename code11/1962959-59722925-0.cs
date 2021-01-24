c#
using System.Drawing;
using System.Drawing.Text;
//...
public enum Glyphs
{
    GlobalNavigationButton = 0xE700,
    Wifi = 0xE701,
    Bluetooth = 0xE702,
    Connect = 0xE703,
    InternetSharing = 0xE704,
    VPN = 0xE705,
    //Add more...
}
//...
public static Icon CreateGlyphIcon(Glyphs glyph)
{
    using (var b = new Bitmap(16, 16))
    using (Graphics g = Graphics.FromImage(b))
    using (var f = new Font("Segoe MDL2 Assets", 12, FontStyle.Regular))
    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
    {
        g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        g.DrawString(((char)glyph).ToString(), f, Brushes.White, new Rectangle(0, 0, 16, 16), sf);
        return Icon.FromHandle(b.GetHicon());
    }                   
}
Usage:
c#
var icon = CreateGlyphIcon(Glyphs.Connect);
//or
var icon = CreateGlyphIcon(Glyphs.Bluetooth);
//...etc.
