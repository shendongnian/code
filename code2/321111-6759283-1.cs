    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    public class Floor
    {
        public Floor(string name = null)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
    public class FakeDb
    {
        public IEnumerable<Floor> Floors
        {
            get
            {
                return new List<Floor>()
                {
                    new Floor("floor1"),
                    new Floor("floor2"),
                    new Floor("floor3"),
                };
            }
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeTabControl();
        }
        private void InitializeTabControl()
        {
            var db = new FakeDb();
            var floorNames = (from fn in db.Floors select fn.Name).ToList();
            foreach (string floorName in floorNames)
            {
                var item = new TabItem()
                {
                    Header = floorName,
                    Content = new Grid(),
                };
                tabControl1.Items.Add(item);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            var rectangle = new Rectangle()
            {
                Stroke = Brushes.Black,
                Fill = Brushes.SkyBlue,
                Width = 50,
                Height = 75,
                Margin = new Thickness(
                    left: random.NextDouble() * 300,
                    top: random.NextDouble() * 150,
                    right: 0,
                    bottom: 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };
            var grid = (Grid)tabControl1.SelectedContent;
            grid.Children.Add(rectangle);
        }
    }
