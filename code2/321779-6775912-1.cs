    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Globalization;
    
    namespace CurrentPageProblem
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            ObservableCollection<PageNumber> pageCollection = new ObservableCollection<PageNumber>();
            public MainWindow()
            {
                InitializeComponent();
    
                pageCollection.Add(new PageNumber("  0  "));
                pageCollection.Add(new PageNumber("  1  "));
                pageCollection.Add(new PageNumber("  2  "));
                pageCollection.Add(new PageNumber("  3  "));
                pageCollection.Add(new PageNumber("  4  "));
                pageCollection.Add(new PageNumber("  5  "));
                
                this.DataContext = this;
            }
    
            public ObservableCollection<PageNumber> PageCollection
            {
                get { return this.pageCollection; }
                set 
                { 
                    this.pageCollection = value;
                    
                }
            }
                
            private int currentPage;
            public int CurrentPage
            {
                get { return currentPage; }
                set 
                { 
                    currentPage = value;
                 
                }
            }
            
            private void button1_Click(object sender, RoutedEventArgs e)
            {
    
                #region -- THIS CODE WORKS FINE NOW --
                pageCollection.Clear();
    
                pageCollection.Add(new PageNumber("  0  "));
                pageCollection.Add(new PageNumber("  1  "));
                pageCollection.Add(new PageNumber("  2  "));
                pageCollection.Add(new PageNumber("  3  "));
                pageCollection.Add(new PageNumber("  4  "));
                pageCollection.Add(new PageNumber("  5  "));
                pageCollection.Add(new PageNumber("  6  "));
                pageCollection.Add(new PageNumber("  7  "));
                pageCollection.Add(new PageNumber("  8  "));
                pageCollection.Add(new PageNumber("  9  "));
                #endregion
                
                currentPage++;
                
            }
     
        }
        public class ButtonColorConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                string current = string.Format("  {0}  ", values[0]);
                string button = (string)values[1];
    
                
                return button == current
                    ? Brushes.NavajoWhite
                    : Brushes.White;  //set the desired color
    
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
        public class PageNumber 
        {
            private string page_Number;
            public PageNumber(string pageNumberArg)
            {
                this.page_Number = pageNumberArg;
            }
            public string Page_Number
            {
                get { return page_Number; }
                set 
                {
                    page_Number = value; 
                }
            }
        }
    }
