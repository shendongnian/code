        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);
            // do the slider scrolling
            //..
            ((HandledMouseEventArgs)e).Handled = true;
        }
