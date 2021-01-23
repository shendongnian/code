    using System.Windows.Controls;
    using System.Windows;
    using System.ComponentModel;
    namespace SilverlightApplication1
    {
        public partial class MainPage : UserControl
        {
            private Data _data;
            public MainPage()
            {
                InitializeComponent();
                _data = new Data { IsSaving = true };
                this.DataContext = _data;
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                _data.IsSaving = !_data.IsSaving;
            }
        }
        public class Data : INotifyPropertyChanged
        {
            #region IsSaving Property
            private bool _isSaving;
            public bool IsSaving
            {
                get
                {
                    return _isSaving;
                }
                set
                {
                    if (_isSaving != value)
                    {
                        _isSaving = value;
                        OnPropertyChanged("IsSaving");
                    }
                }
            }
            #endregion
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                var p = PropertyChanged;
                if (p != null)
                {
                    p(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
