    public class BottomDockingPanel : DockPanel
    {
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            UIElementCollection children = InternalChildren;
            int totalChildrenCount = children.Count;
            double accumulatedBottom = 0;
            for (int i = totalChildrenCount-1; i >=0 ; --i)
            {
                UIElement child = children[i];
                if (child == null) { continue; }
                Size childDesiredSize = child.DesiredSize;
                Rect rcChild = new Rect(
                    0,
                    0,
                    Math.Max(0.0, arrangeSize.Width - (0 + (double)0)),
                    Math.Max(0.0, arrangeSize.Height - (0 + accumulatedBottom)));
                if (i > 0)
                {
                    accumulatedBottom += childDesiredSize.Height;
                    rcChild.Y = Math.Max(0.0, arrangeSize.Height - accumulatedBottom);
                    rcChild.Height = childDesiredSize.Height;
                }
                child.Arrange(rcChild);
            }
            return (arrangeSize);
        }
    }
