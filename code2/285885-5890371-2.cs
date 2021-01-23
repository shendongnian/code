        public MainWindow()
        {
            InitializeComponent();
            SetBinding(IsTextBoxFocusedProperty,
                new Binding
                {
                    Path = new PropertyPath("IsMyTextBeingEdited"),
                    Mode = BindingMode.OneWayToSource,
                });
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            IsTextBoxFocused = false;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            IsTextBoxFocused = true;
        }
        #region IsTextBoxFocused
        /// <summary>
        /// Gets or Sets IsTextBoxFocused
        /// </summary>
        public bool IsTextBoxFocused
        {
            get
            {
                return (bool)this.GetValue(IsTextBoxFocusedProperty);
            }
            set
            {
                this.SetValue(IsTextBoxFocusedProperty, value);
            }
        }
        /// <summary>
        /// The backing DependencyProperty behind IsTextBoxFocused
        /// </summary>
        public static readonly DependencyProperty IsTextBoxFocusedProperty = DependencyProperty.Register(
          "IsTextBoxFocused", typeof(bool), typeof(MainWindow), new PropertyMetadata(default(bool)));
        #endregion
