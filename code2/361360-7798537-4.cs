    public static readonly DependencyProperty IsButtonMouseOverProperty = DependencyProperty.Register("IsButtonMouseOver",
        typeof(bool), typeof(ToolbarButtonCombo), new PropertyMetadata(false));
        public bool IsButtonMouseOver
        {
            get { return (bool)this.GetValue(IsButtonMouseOverProperty); }
            set { this.SetValue(IsButtonMouseOverProperty, value); }
        }
        void btn_MouseChanged(object sender, MouseEventArgs e)
        {
            this.IsButtonMouseOver = this.btn.IsMouseOver;
        }
