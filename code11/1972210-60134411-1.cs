public void buildOval<T>(int oWDelta, int oHDelta, T o = null) where T : Control
{
     var width = o == null ? this.Width : o.Width;
     var height = o == null ? this.Height : o.Height;
     System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
     gp.AddEllipse(0, 0, width - oWDelta, height - oHDelta);
     Region rg = new Region(gp);
     o.Region = rg;
}
As @madreflection suggested in his comment , it could be non-generic version too. For example,
public void buildOval<T>(int oWDelta, int oHDelta, Control o = null) 
{
    var width = o == null ? this.Width : o.Width;
    var height = o == null ? this.Height : o.Height;
    System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
    gp.AddEllipse(0, 0, width - oWDelta, height - oHDelta);
    Region rg = new Region(gp);
    o.Region = rg;
}
