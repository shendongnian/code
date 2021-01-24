    class RoiAdorner : Adorner
    {
        public double factorX = 0d;
        public double factorY = 0d;
        public Rect rectangle = new Rect();
        public RoiAdorner(UIElement adornedElement) : base(adornedElement)
        {
            rectangle.Height = 30;
            rectangle.Width = 100;
            IsHitTestVisible = false;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (factorY == 0)
                factorY =  rectangle.Height / AdornedElement.DesiredSize.Height;
            if (factorX == 0)
                factorX = rectangle.Width / AdornedElement.DesiredSize.Width;
            var r = new Rect(new Size(AdornedElement.DesiredSize.Width * factorX, AdornedElement.DesiredSize.Height * factorY));
            //Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            drawingContext.DrawRectangle(null, new Pen(Brushes.Red, 5), r);
        }
