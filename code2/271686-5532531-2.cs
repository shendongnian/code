    public class MyAdorner: Adorner
    {
        ctor (...):base(...)
        {
            ...
            
            var storyboard = new Storyboard();
            var doubleAnimation = new DoubleAnimation(0.2,new Duration(TimeSpan.Zero));
            Storyboard.SetTarget(doubleAnimation,this);
            Storyboard.SetTargetProperty(doubleAnimation,new PropertyPath(RectOpacityProperty));
            storyboard.Children.Add(doubleAnimation);
            var storyboard2 = new Storyboard();
            var doubleAnimation2 = new DoubleAnimation(0.5, new Duration(TimeSpan.Zero));
            Storyboard.SetTarget(doubleAnimation2, this);
            Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(RectOpacityProperty));
            storyboard2.Children.Add(doubleAnimation2);
            var stateGroup = new VisualStateGroup { Name = "MouseOverState" };
            stateGroup.States.Add(new VisualState { Name = "MouseOut", Storyboard = storyboard });
            stateGroup.States.Add(new VisualState { Name = "MouseOver", Storyboard = storyboard2});
            var sgs = VisualStateManager.GetVisualStateGroups(this);
            sgs.Add(stateGroup);
            var dsb = new DataStateBehavior
                {
                    Value = true,
                    FalseState = "MouseOut",
                    TrueState = "MouseOver"
                };
            BindingOperations.SetBinding(dsb, DataStateBehavior.BindingProperty, new Binding {Source = this, Path = new PropertyPath(IsMouseOverProperty)});
            dsb.Attach(this);
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(_mouseOverBrush, _pen, _rects[i]);     //mouseoverbrush is a Solidcolorbrush       
        }
        public double RectOpacity
        {
            get { return (double)GetValue(RectOpacityProperty); }
            set { SetValue(RectOpacityProperty, value); }
        }
        public static readonly DependencyProperty RectOpacityProperty =
            DependencyProperty.Register("RectOpacity", typeof(double), typeof(XmlNodeWrapperAdorner), new FrameworkPropertyMetadata(0.0,FrameworkPropertyMetadataOptions.AffectsRender,(o, args) =>
                {
                    var adorner = o as MyAdorner;
                    adorner._mouseOverBrush.Color = Color.FromArgb((byte)((double)args.NewValue * 0xFF), 0xFF, 0xBE, 0x00);
                }));
    }
