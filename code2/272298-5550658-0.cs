        /// <summary>
        /// BindableInScopeItemIds Dependency Property
        /// </summary>
        public static readonly DependencyProperty BindableInScopeItemIdsProperty =
            DependencyProperty.Register("BindableInScopeItemIds", typeof(ICollection<string>), typeof(CustomPivotViewer),
                new PropertyMetadata(null,
                    new PropertyChangedCallback(OnBindableInScopeItemIdsChanged)));
        /// <summary>
        /// Gets or sets the BindableInScopeItemIds property. This dependency property 
        /// indicates ....
        /// </summary>
        public ICollection<string> BindableInScopeItemIds
        {
            get { return (ICollection<string>)GetValue(BindableInScopeItemIdsProperty); }
            set { SetValue(BindableInScopeItemIdsProperty, value); }
        }
        /// <summary>
        /// Handles changes to the BindableInScopeItemIds property.
        /// </summary>
        private static void OnBindableInScopeItemIdsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (CustomPivotViewer)d;
            ICollection<string> oldBindableInScopeItemIds = (ICollection<string>)e.OldValue;
            ICollection<string> newBindableInScopeItemIds = target.BindableInScopeItemIds;
            target.OnBindableInScopeItemIdsChanged(oldBindableInScopeItemIds, newBindableInScopeItemIds);
        }
        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the BindableInScopeItemIds property.
        /// </summary>
        protected virtual void OnBindableInScopeItemIdsChanged(ICollection<string> oldBindableInScopeItemIds, ICollection<string> newBindableInScopeItemIds)
        {
        }
