    using System.Windows;
    using System.Windows.Input;
    using System.ComponentModel;
    namespace MutuallyExclusiveMenuItems
    {
      public partial class MainWindow : Window, INotifyPropertyChanged
      {
        public MainWindow()
        {
          InitializeComponent();
          DataContext = this;
        }
        #region Enum Property
        public enum CurrentItemEnum { EnumItem1, EnumItem2, EnumItem3 };
        private CurrentItemEnum _currentMenuItem;
        public CurrentItemEnum CurrentMenuItem
        {
          get { return _currentMenuItem; }
          set
          {
            _currentMenuItem = value;
            OnPropertyChanged("CurrentMenuItem");
          }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Enum Property
        #region Commands
        public static RoutedUICommand MenuItem1Cmd = 
          new RoutedUICommand("Item_1", "Item1cmd", typeof(MainWindow));
        public void MenuItem1Execute(object sender, ExecutedRoutedEventArgs e)
        {
          CurrentMenuItem = CurrentItemEnum.EnumItem1;
        }
        public static RoutedUICommand MenuItem2Cmd = 
          new RoutedUICommand("Item_2", "Item2cmd", typeof(MainWindow));
        public void MenuItem2Execute(object sender, ExecutedRoutedEventArgs e)
        {
          CurrentMenuItem = CurrentItemEnum.EnumItem2;
        }
        public static RoutedUICommand MenuItem3Cmd = 
          new RoutedUICommand("Item_3", "Item3cmd", typeof(MainWindow));
        public void MenuItem3Execute(object sender, ExecutedRoutedEventArgs e)
        {
          CurrentMenuItem = CurrentItemEnum.EnumItem3;
        }
        public void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
          e.CanExecute = true;
        }
        #endregion Commands
      }
    }
