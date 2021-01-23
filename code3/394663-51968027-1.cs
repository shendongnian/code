    using System;
    using System.ComponentModel;
    using System.Windows;
    namespace DelayedControl
    {
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
        
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this; // treat this as a view model for simplification..
            }
        
            public string DelayedViewProperty
            {
                get => delayedViewProperty;
                set
                {
                    delayedViewProperty = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DelayedViewProperty)));
                }
            }
            private string delayedViewProperty;
            private void Foo_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (e.NewValue is INotifyPropertyChanged vm)
                {
                    // Forward updates of the view model property to the foo.Tag
                    vm.PropertyChanged += (s, args) =>
                    {
                        var propertyName = nameof(ViewModelProperty);
                        if (args.PropertyName == propertyName && s?.GetType().GetProperty(propertyName)?.GetValue(s) is var tag)
                        {
                            foo.Tag = tag;  // Dispatcher might be needed if the change is triggered from a different thread..
                        }
                    };
                }
            }
        
            public string ViewModelProperty
            {
                get => viewModelProperty;
                set
                {
                    viewModelProperty = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ViewModelProperty)));
                }
            }
            private string viewModelProperty;
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                ViewModelProperty = DateTime.Now.ToString("hh:mm:ss.fff");
            }
        }
    }
