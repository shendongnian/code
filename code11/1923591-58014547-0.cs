        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            drawingContext.DrawRectangle(null, new Pen(Brushes.Green, 5), adornedElementRect);
        }
