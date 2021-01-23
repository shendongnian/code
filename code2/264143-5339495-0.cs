    /// <summary>
    /// A behavior that forces the associated popup to update its position when the <see cref="Popup.PlacementTarget"/>
    /// location has changed.
    /// </summary>
    public class AutoRepositionPopupBehavior : Behavior<Popup> {
        public Point StartPoint = new Point(0, 0);
        public Point EndPoint = new Point(0, 0);
    
        protected override void OnAttached() {
            base.OnAttached();
    
            if (AssociatedObject.PlacementTarget != null) {
                AssociatedObject.PlacementTarget.LayoutUpdated += OnPopupTargetLayoutUpdated;
            }
        }
    
        void OnPopupTargetLayoutUpdated(object sender, EventArgs e) {
            if (AssociatedObject.IsOpen) {
                ResetPopUp();
            }
        }
    
        public void ResetPopUp() {
            // The following trick that forces the popup to change it's position was taken from here:
            // http://social.msdn.microsoft.com/Forums/en-US/wpf/thread/27950e73-0007-4e0b-9f00-568d2db1d979
            Random random = new Random();
            AssociatedObject.PlacementRectangle = new Rect(new Point(random.NextDouble() / 1000, 0), new Size(75, 25));
        }
    }
