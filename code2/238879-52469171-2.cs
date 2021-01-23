    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    namespace MultiRegionListBox
    {
        class SharedLayoutStackPanel : Panel, IScrollInfo
        {
            internal const double _scrollLineDelta = 16.0;
            public void LineUp() => SetVerticalOffset(VerticalOffset - _scrollLineDelta);
            public void LineDown() => SetVerticalOffset(VerticalOffset + _scrollLineDelta);
            public void LineLeft() => SetHorizontalOffset(HorizontalOffset - 1.0);
            public void LineRight() => SetHorizontalOffset(HorizontalOffset + 1.0);
            public void PageUp() => SetVerticalOffset(VerticalOffset - ViewportHeight);
            public void PageDown() => SetVerticalOffset(VerticalOffset + ViewportHeight);
            public void PageLeft() => SetHorizontalOffset(HorizontalOffset - ViewportWidth);
            public void PageRight() => SetHorizontalOffset(HorizontalOffset + ViewportWidth);
            public void MouseWheelUp() => SetVerticalOffset(VerticalOffset - SystemParameters.WheelScrollLines * _scrollLineDelta);
            public void MouseWheelDown() => SetVerticalOffset(VerticalOffset + SystemParameters.WheelScrollLines * _scrollLineDelta);
            public void MouseWheelLeft() => SetHorizontalOffset(HorizontalOffset - 3.0 * _scrollLineDelta);
            public void MouseWheelRight() => SetHorizontalOffset(HorizontalOffset + 3.0 * _scrollLineDelta);
            public double ExtentWidth => Extent.Width;
            public double ExtentHeight => Extent.Height;
            public double ViewportWidth => Viewport.Width;
            public double ViewportHeight => Viewport.Height;
            public double HorizontalOffset => ComputedOffset.X;
            public double VerticalOffset => ComputedOffset.Y;
            public void SetHorizontalOffset(double offset)
            {
                if (double.IsNaN(offset))
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (offset < 0d)
                {
                    offset = 0d;
                }
                if (offset != Offset.X)
                {
                    Offset.X = offset;
                    InvalidateMeasure();
                }
            }
            /// <summary>
            /// Set the VerticalOffset to the passed value.
            /// </summary>
            public void SetVerticalOffset(double offset)
            {
                if (double.IsNaN(offset))
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (offset < 0d)
                {
                    offset = 0d;
                }
                if (offset != Offset.Y)
                {
                    Offset.Y = offset;
                    InvalidateMeasure();
                }
            }
            public ScrollViewer ScrollOwner
            {
                get { return _scrollOwner; }
                set
                {
                    if (value == _scrollOwner)
                    {
                        return;
                    }
                    InvalidateMeasure();
                    Offset = new Vector();
                    Viewport = Extent = new Size();
                    _scrollOwner = value;
                }
            }
            public bool CanVerticallyScroll
            {
                get { return true; }
                set { /* noop */ }
            }
            public bool CanHorizontallyScroll
            {
                get { return false; }
                set { /* noop */ }
            }
            internal bool IsMeasureMeaningless { get; private set; }
            protected override void OnVisualParentChanged(DependencyObject oldParent)
            {
                base.OnVisualParentChanged(oldParent);
                this.SLC = SharedLayoutCoordinator.GetParentSharedLayoutController(this);
                if (SLC != null)
                {
                    this.SLC.Panel = this;
                }
                InvalidateMeasure();
            }
            protected override Size MeasureOverride(Size viewportSize)
            {
                if (SLC == null || !SLC.CanMeasure(InvalidateMeasure))
                {
                    IsMeasureMeaningless = true;
                    return viewportSize;
                }
                IsMeasureMeaningless = false;
                var extent = new Size();
                var countInRegion = 0; var hasNextRegion = SLC.HasNextRegion;
                foreach (var child in InternalChildren.Cast<UIElement>().Skip(SLC.StartOfRegion))
                {
                    child.Measure(new Size(viewportSize.Width, double.PositiveInfinity));
                    var childDesiredSize = child.DesiredSize;
                    if (hasNextRegion && extent.Height + childDesiredSize.Height > viewportSize.Height)
                    {
                        break;
                    }
                    extent.Width = Math.Max(extent.Width, childDesiredSize.Width);
                    extent.Height += childDesiredSize.Height;
                    SLC.CountInRegion = countInRegion += 1;
                }
                // Update ISI
                this.Extent = extent;
                this.Viewport = viewportSize;
                this.ComputedOffset.Y = Bound(Offset.Y, 0, extent.Height - viewportSize.Height);
                this.OnScrollChange();
                SLC.OnMeasure();
                return new Size(
                    Math.Min(extent.Width, viewportSize.Width),
                    Math.Min(extent.Height, viewportSize.Height));
            }
            private static double Bound(double c, double min, double max)
                => Math.Min(Math.Max(c, Math.Min(min, max)), Math.Max(min, max));
            protected override Size ArrangeOverride(Size arrangeSize)
            {
                if (IsMeasureMeaningless)
                {
                    return arrangeSize;
                }
                double cy = -ComputedOffset.Y;
                int i = 0, i_start = SLC.StartOfRegion, i_end = SLC.EndOfRegion;
                foreach (UIElement child in InternalChildren)
                {
                    if (i >= i_start && i < i_end)
                    {
                        child.Arrange(new Rect(0, cy, Math.Max(child.DesiredSize.Width, arrangeSize.Width), child.DesiredSize.Height));
                        cy += child.DesiredSize.Height;
                    }
                    else if (child.RenderSize != new Size())
                    {
                        child.Arrange(new Rect());
                    }
                    i += 1;
                }
                return arrangeSize;
            }
            private void OnScrollChange() => ScrollOwner?.InvalidateScrollInfo();
            public Rect MakeVisible(Visual visual, Rect rectangle)
            {
                // no-op
                return rectangle;
            }
            internal ScrollViewer _scrollOwner;
            internal Vector Offset;
            private Size Viewport;
            private Size Extent;
            private Vector ComputedOffset;
            private SharedLayoutRegion SLC;
        }
    }
