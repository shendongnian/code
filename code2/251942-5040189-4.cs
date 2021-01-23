        [IsCustomProperty(true)]
        [DisplayName("Orientation")]
        public bool ScaleVisibility
        {
            get { return (bool)GetValue(ScaleVisibilityProperty); }
            set { SetValue(ScaleVisibilityProperty, value); }
        }
        public static readonly DependencyProperty ScaleVisibilityProperty =
            DependencyProperty.Register("ScaleVisibility", typeof(bool),
            typeof(IC_BarControl), new UIPropertyMetadata(true));
