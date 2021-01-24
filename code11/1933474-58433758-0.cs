    namespace ControlsAndResources
    {
        public class View
        {
            private static readonly ViewModelLocator s_viewModelLocator = new ViewModelLocator();
            public static readonly DependencyProperty ViewModelProperty = DependencyProperty.RegisterAttached("ViewModel", typeof(string), 
                typeof(ViewModelLocator), new PropertyMetadata(new PropertyChangedCallback(OnChanged)));
            public static void SetViewModel(UserControl view, string value) => view.SetValue(ViewModelProperty, value);
            public static string GetViewModel(UserControl view) => (string)view.GetValue(ViewModelProperty);
            private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                UserControl view = (UserControl)d;
                string viewModel = e.NewValue as string;
                switch (viewModel)
                {
                    case "MainViewModel":
                        view.DataContext = s_viewModelLocator.MainViewModel;
                        break;
                    case "FooViewModel":
                        view.DataContext = s_viewModelLocator.FooViewModel;
                        break;
                    default:
                        view.DataContext = null;
                        break;
                }
            }
        }
    }
