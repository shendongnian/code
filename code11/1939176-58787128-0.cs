    public class TextViewer : FrameworkElement
    {
        // For highlighting of the selected line.
        private DrawingVisual selectionLineAppearance = new DrawingVisual();
    
        // For highlighting tokens of the lines.
        private VisualCollection lines;
    
        protected override int VisualChildrenCount
        {
            // selectionLineAppearance + lines
            get { return 1+lines.Count; }
        }
    
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= VisualChildrenCount)
                throw new ArgumentOutOfRangeException();
    
            if (index == 0) return this.selectionLineAppearance;
            return lines[index-1];
        }
    
        // logices
        ...
    
    }
