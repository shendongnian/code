      public static readonly DependencyProperty ProjectItemProperty =
            DependencyProperty.Register(
                nameof(ProjectItem),
                typeof(ProjectItem),
                typeof(MyUserControl1),
                null);
        public ProjectItem ProjectItem
        {
            get => (ProjectItem)GetValue(ProjectItemProperty);
            set => SetValue(ProjectItemProperty, value);
        }
