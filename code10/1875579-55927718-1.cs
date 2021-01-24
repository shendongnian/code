    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public ObservableCollection<Track> Tracks { get; set; }
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
    
                Tracks = new ObservableCollection<Track>();
                AddTrack("01","Three Days Grace - I Hate Everything About You (Official Music Video)", "3:45", new BitmapImage(new Uri("pack://application:,,,/WpfApp1;component/Resources/pobrane.jpg")));
            }
    
            public void AddTrack (string number, string name, string length, ImageSource image)
            {
                var track = new Track();
                track.Number = number;
                track.Name = name;
                track.Length = length;
                track.Image = image;
                Tracks.Add(track);
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                AddTrack("01", "Three Days Grace - I Hate Everything About You (Official Music Video)", "3:45", new BitmapImage(new Uri("pack://application:,,,/WpfApp1;component/Resources/pobrane.jpg")));
            }
        }
    
        public class Track
        {
            public string Number { get; set; }
    
            public string Name { get; set; }
    
            public string Length { get; set; }
    
            public ImageSource Image { get; set; }
        }
    }
