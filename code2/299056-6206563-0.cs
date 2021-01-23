    public class MyTabItem : TabItem {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {
            if (e.Source == this || !this.IsSelected)
                return;
            base.OnMouseLeftButtonDown(e);
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e) {
            if (e.Source == this || !this.IsSelected)
                base.OnMouseLeftButtonDown(e); // OR just this.Focus(); OR this.IsSeleded = true;
            base.OnMouseLeftButtonUp(e);
        }
    }
