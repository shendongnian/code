    public delegate void RenderEventHandler(CanvasRender sender, DrawingContext dc);
    public class CanvasRender : Canvas
    {
        public event RenderEventHandler Render;
        public CanvasRender()
        {
        }
        protected override void OnRender(DrawingContext dc)
        {
            if (Render != null)
                Render(this, dc);
            base.OnRender(dc);
        }
    }
