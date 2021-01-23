ModalView.cs
    [TemplatePart(Name = "PART_ModalContent", Type = typeof(ContentPresenter))]
    [TemplatePart(Name = "PART_PrimaryContent", Type = typeof(ContentPresenter))]
    public class ModalView : ContentControl
    {
        private bool _cachedEnabledValue = true;
        private UIElement _modalContent;
        private UIElement _primaryContent;
        public static readonly DependencyProperty IsShownProperty =
            DependencyProperty.Register("IsShown",
            typeof(bool),
            typeof(ModalView),
            new UIPropertyMetadata(false, IsShownChangedCallback));
        public static readonly DependencyProperty ModalContentProperty =
            DependencyProperty.Register("ModalContent", 
            typeof(object),
            typeof(ModalView), 
            new UIPropertyMetadata(null));
        public ModalView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModalView),
                new FrameworkPropertyMetadata(typeof(ModalView)));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _modalContent = base.GetTemplateChild("PART_ModalContent") as UIElement;
            if (_modalContent != null)
            {
                _modalContent.Visibility = Visibility.Hidden;
            }
            _primaryContent = base.GetTemplateChild("PART_PrimaryContent") as UIElement;
        }
        public object ModalContent
        {
            get { return ( object)GetValue(ModalContentProperty); }
            set { SetValue(ModalContentProperty, value); }
        }
        public bool IsShown
        {
            get { return (bool)GetValue(IsShownProperty); }
            set { SetValue(IsShownProperty, value); }
        }
        private static void IsShownChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ModalView dialog = (ModalView)d;
            if ((bool)e.NewValue == true)
            {
                dialog.Show();
            }
            else
            {
                dialog.Hide();
            }
        }
        private void Show()
        {
            if (_modalContent != null)
            {
                _modalContent.Visibility = Visibility.Visible;
            }
            if (_primaryContent != null)
            {
                _cachedEnabledValue = _primaryContent.IsEnabled;
                _primaryContent.IsEnabled = false;
            }
        }
        private void Hide()
        {
            if (_modalContent != null)
            {
                _modalContent.Visibility = Visibility.Hidden;
            }
            if (_primaryContent != null)
            {
                _primaryContent.IsEnabled = _cachedEnabledValue;
            }
        }
    }
