    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApplication2
    {
        public partial class MainWindow : Window
        {
            private CodeLines lines;
            public MainWindow()
            {
                InitializeComponent();
                lines = new CodeLines();
                Random random = new Random();
                for (int i = 0; i < 200; i++)
                {
                    lines.Add(new CodeLine { Status = (VersionStatus)random.Next(0, 5), Line = "Line " + i });
                }
                this.DataContext = lines;
                codeBox.Text = String.Join("\n",  from line in lines
                                                select line.Line);
            }
            private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var selectedLine = ((ListBox)sender).SelectedIndex;
                codeBox.ScrollToLine(selectedLine);
            }
        }
        public enum VersionStatus
        {
            Original,
            Added,
            Modified,
            Deleted
        }
        public class CodeLine : INotifyPropertyChanged
        {
            private VersionStatus status;
            public VersionStatus Status
            {
                get { return status; }
                set
                {
                    if (status != value)
                    {
                        status = value;
                        OnPropertyChanged("Status");
                    }
                }
            }
            private string line;
            public string Line
            {
                get { return line; }
                set
                {
                    if (line != value)
                    {
                        line = value;
                        OnPropertyChanged("Line");
                    }
                }
            }
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
        public class CodeLines : ObservableCollection<CodeLine>
        {
        }
    
        class StatusToBrushConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var status = (VersionStatus)value;
                switch (status)
                {
                    case VersionStatus.Original:
                        return Brushes.Green;
                    case VersionStatus.Added:
                        return Brushes.Blue;
                    case VersionStatus.Modified:
                        return Brushes.Yellow;
                    case VersionStatus.Deleted:
                        return Brushes.Red;
                    default:
                        return DependencyProperty.UnsetValue;
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
