        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            (((this.GetVisualChild(0) as Grid).Children)[1] as System.Windows.Controls.Primitives.ToggleButton).IsEnabled = false;
        }
