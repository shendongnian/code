        protected override void OnRender(DrawingContext drawingContext)
        {
            TextPointer start;
            TextPointer end;
            // Find the start and end of your word
            // Actually, if you did this in the TextChanged event handler,
            // you could probably save some calculation time on large texts
            // by considering what actually changed relative to an earlier
            // calculation. (TextChangedEventArgs includes a list of changes
            //  - 'n' characters inserted here, 'm' characters deleted there).
            Rect startRect = start.GetCharacterRect(LogicalDirection.Backward);
            Rect endRect = end.GetCharacterRect(LogicalDirection.Forward);
            drawingContext.DrawRectangle(null, pen, Rect.Union(startRect, endRect));
        }
