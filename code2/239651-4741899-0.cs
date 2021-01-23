    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows;
    public class DelegatePanel : Panel
    {
        private sealed class DelegateChild : FrameworkElement
        {
            readonly Func<Size, Size> measure;
            readonly Func<Size, Size> arrange;
            public DelegateChild(Func<Size,Size> measure, Func<Size,Size> arrange)
            {
                this.measure = measure;
                this.arrange = arrange;
            }
            protected override Size MeasureOverride(Size availableSize)
            {
                return measure(availableSize);
            }
            protected override Size ArrangeOverride(Size finalSize)
            {
                return arrange(finalSize);
            }
        }
        readonly Dictionary<UIElement, UIElement> delegateByChild = new Dictionary<UIElement,UIElement>();
        public Panel LayoutPanel
        {
            get { return (Panel)GetValue(LayoutPanelProperty); }
            set { SetValue(LayoutPanelProperty, value); }
        }
        public static readonly DependencyProperty LayoutPanelProperty =
            DependencyProperty.Register("LayoutPanel", typeof(Panel), typeof(DelegatePanel), new PropertyMetadata(null));
        protected override Size MeasureOverride(Size availableSize)
        {
            if(this.LayoutPanel==null)
                return base.MeasureOverride(availableSize);
            this.delegateByChild.Clear();
            this.LayoutPanel.Children.Clear();
            foreach (UIElement _child in this.Children)
            {
                var child = _child;
                var delegateChild = new DelegateChild(
                        availableChildSize =>
                        {
                            child.Measure(availableChildSize);
                            return child.DesiredSize;
                        },
                        finalChildSize =>
                        {
                            return finalChildSize;
                        });
                delegateByChild[child] = delegateChild;
                this.LayoutPanel.Children.Add(delegateChild);
            }
            this.LayoutPanel.Measure(availableSize);
            return this.LayoutPanel.DesiredSize;
        }
        protected override Size  ArrangeOverride(Size finalSize)
        {
            if(this.LayoutPanel==null)
 	            return base.ArrangeOverride(finalSize);
            this.LayoutPanel.Arrange(new Rect(finalSize));
            foreach (var kv in delegateByChild)
	        {
                var child = kv.Key;
                var delegateChild = kv.Value;
                var position = delegateChild.TranslatePoint(default(Point), this.LayoutPanel);
                Rect finalChildBounds = new Rect(
                    position,
                    delegateChild.RenderSize);
                child.Arrange(finalChildBounds);
	        }
            return this.LayoutPanel.RenderSize;
        }
    }
