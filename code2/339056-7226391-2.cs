    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Collections.ObjectModel;
    
    namespace TestImage
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                MyData data1 = new MyData() { Id = 1, ImagePath = "http://www.rhyous.com/wp-content/themes/rhyous/swordtop.png" };
                MyImage.DataContext = data1;
    
                ObservableCollection<MyData> DataList = new ObservableCollection<MyData>();
                DataList.Add(data1);
                MyData data2 = data2 = new MyData() { Id = 2, ImagePath = "http://gigabit.com/images/whmcslogo.gif" };
    
                MyDataGrid.ItemsSource = DataList;
            }
        }
    
        public class MyData
        {
            public String ImagePath { get; set; }
            public int Id { get; set; }
    
        }
    }
