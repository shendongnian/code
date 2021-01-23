    public class SelectionComboBox : ComboBox
    {
        #region Properties
        #region Dependency Properties
        public DataTemplate AltSelectionBoxItemTemplate
        {
            get { return (DataTemplate)GetValue(AltSelectionBoxItemTemplateProperty); }
            set { SetValue(AltSelectionBoxItemTemplateProperty, value); }
        }
        public static readonly DependencyProperty AltSelectionBoxItemTemplateProperty =
            DependencyProperty.Register("AltSelectionBoxItemTemplate", typeof(DataTemplate), typeof(SelectionComboBox), new UIPropertyMetadata(null, (s, e) =>
            {
                // For new changes...
                if ((s is SelectionComboBox) && ((SelectionComboBox)s).Presenter != null && (e.NewValue is DataTemplate))
                    ((SelectionComboBox)s).Presenter.ContentTemplate = (DataTemplate)e.NewValue;
                
                // Set the new value
                ((SelectionComboBox)s).AltSelectionBoxItemTemplate = (DataTemplate)e.NewValue;
            }));
        #endregion
        #region Internals
        #region Elements
        ContentPresenter Presenter { get; set; }
        #endregion
        #endregion
        #endregion
        #region Constructors
        #endregion
        #region Methods
        #region Overrides
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Presenter = this.GetTemplateChild("contentPresenter") as ContentPresenter;
            // Directly Set the selected item template
            if (AltSelectionBoxItemTemplate != null) Presenter.ContentTemplate = AltSelectionBoxItemTemplate;
        }
        #endregion
        #endregion
    }
