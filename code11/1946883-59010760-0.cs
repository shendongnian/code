    using System;
    using System.Windows;
    using System.Windows.Media;
    
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            private static MediaPlayer _backgroundMusic = new MediaPlayer();
    
            public MainWindow()
            {
                InitializeComponent();
    
                StartBackgroundMusic();
            }
    
            public static void StartBackgroundMusic()
            {
                _backgroundMusic.Open(new Uri(@"C:\<path-to-sound-file>\music.wav"));
                _backgroundMusic.MediaEnded += new EventHandler(BackgroundMusic_Ended);
                _backgroundMusic.Play();
            }
    
            private static void BackgroundMusic_Ended(object sender, EventArgs e)
            {
                _backgroundMusic.Position = TimeSpan.Zero;
                _backgroundMusic.Play();
            }
        }
    }
