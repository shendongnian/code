c#
// PCL
public class BoxViewExt : BoxView
{
}
// Android
public class BoxViewExtRenderer : BoxRenderer
{
    public BoxViewExtRenderer(Context context) : base(context)
    {
    }
    protected override void OnDraw(Canvas canvas)
    {
        base.OnDraw(canvas);
        var paint = new Paint { StrokeWidth = 2, AntiAlias = true };
        paint.SetStyle(Paint.Style.Stroke);
        paint.SetPathEffect(new DashPathEffect(new[] { 6 * this.Context.Resources.DisplayMetrics.Density, 2 * this.Context.Resources.DisplayMetrics.Density }, 0));
        var p = new Path();
        p.LineTo(canvas.Width, 0);
        canvas.DrawPath(p, paint);
    }
}
