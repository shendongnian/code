        protected override void OnRender(DrawingContext drawingContext)
        {
            TextPointer start;
            TextPointer end;
            // find the start and end of your word
            Rect startRect = start.GetCharacterRect(LogicalDirection.Backward);
            Rect endRect = end.GetCharacterRect(LogicalDirection.Forward);
            drawingContext.DrawRectangle(null, pen, Rect.Union(startRect, endRect));
        }
