C#
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
[ToolboxBitmap(typeof(ListBox)),
    DesignerCategory("")]
public class TransparentListBox : ListBox
{
    public TransparentListBox() : base()
    {
        SetStyle(
            ControlStyles.Opaque |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.ResizeRedraw |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer, true);
        DrawMode = DrawMode.OwnerDrawFixed;
    }
    //...
Now we need to override both the `OnPaint` and `OnDrawItem` events to do the drawing. The [DrawThemeParentBackground](https://docs.microsoft.com/en-us/windows/win32/api/uxtheme/nf-uxtheme-drawthemeparentbackground) function is required to copy the parent's background, just the region of our control. Also we have a new member, the `SelectionBackColor` property, the background color of the selected items:
c#
    //...
    public Color SelectionBackColor { get; set; } = Color.DarkOrange;
    [DllImport("uxtheme", ExactSpelling = true)]
    private extern static int DrawThemeParentBackground(
        IntPtr hWnd, 
        IntPtr hdc, 
        ref Rectangle pRect
        );
    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        var rec = ClientRectangle;
        IntPtr hdc = g.GetHdc();
        DrawThemeParentBackground(this.Handle, hdc, ref rec);
        g.ReleaseHdc(hdc);
        using (Region reg = new Region(e.ClipRectangle))
        {
            if (Items.Count > 0)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    rec = GetItemRectangle(i);
                    if (e.ClipRectangle.IntersectsWith(rec))
                    {
                        if ((SelectionMode == SelectionMode.One && SelectedIndex == i) ||
                            (SelectionMode == SelectionMode.MultiSimple && SelectedIndices.Contains(i)) ||
                            (SelectionMode == SelectionMode.MultiExtended && SelectedIndices.Contains(i)))
                            OnDrawItem(new DrawItemEventArgs(g, Font, rec, i, DrawItemState.Selected, ForeColor, BackColor));
                        else
                            OnDrawItem(new DrawItemEventArgs(g, Font, rec, i, DrawItemState.Default, ForeColor, BackColor));
                        reg.Complement(rec);
                    }
                }
            }
        }            
    }
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if (e.Index < 0) return;
        var rec = e.Bounds;
        var g = e.Graphics;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            using (SolidBrush sb = new SolidBrush(SelectionBackColor))
                g.FillRectangle(sb, rec);
        using (SolidBrush sb = new SolidBrush(ForeColor))
        using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
            g.DrawString(GetItemText(Items[e.Index]), Font, sb, rec, sf);
    }
    //...
The hard part is done. To finish up, the drawing should be refreshed on occurrence of certain events, otherwise it will be a visual chaos:
c#
    //...
    protected override void OnSelectedIndexChanged(EventArgs e)
    {
        base.OnSelectedIndexChanged(e);
        Invalidate();
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        Invalidate();
    }
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);
        Invalidate();
    }
    //...
Also, a refresh is required when using both, the vertical and horizontal scroll bars. Doing that is possible by overriding the `WndProc` since the ListBox control does not have any scroll events. 
c#
    //...
    private const int WM_KILLFOCUS  = 0x8;
    private const int WM_VSCROLL    = 0x115;
    private const int WM_HSCROLL    = 0x114;
    protected override void WndProc(ref Message m)
    {
        if (m.Msg != WM_KILLFOCUS && 
            (m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL))
            Invalidate();
        base.WndProc(ref m);
    }
}
That's is. Puzzle up, rebuild and try.
[![TransparentListBox][1]][1]
  [1]: https://i.stack.imgur.com/hVNxd.gif
