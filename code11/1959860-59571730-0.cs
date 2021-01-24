        #region public string IcoIcon
        public string IcoIcon
        {
            get { return (string)GetValue(IcoIconProperty); }
            set { SetValue(IcoIconProperty, value); }
        }
        /// <summary>
        /// Identifies the IcoIcon dependency property.
        /// </summary>
        public static readonly DependencyProperty IcoIconProperty =
            DependencyProperty.Register(
                "IcoIcon",
                typeof(string),
                typeof(MainWindow),
                new PropertyMetadata(string.Empty));
        #endregion public string IcoIcon 
