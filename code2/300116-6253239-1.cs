    using System;
    using System.Windows;
    namespace Sistema.Util
    {
        /// <summary>
        /// Interaction logic for WindowPlay.xaml
        /// </summary>
        public partial class WindowPlay : Window
        {
            public WindowPlay()
            {
                try
                {
                    InitializeComponent();
                }
                catch
                {
                    this.Close();
                }
            }
            /// <summary>
            /// Plays the specified file name
            /// </summary>
            /// <param name="FileName">The filename to play</param>
            /// <param name="Async">If True play in background and return immediatelly the control to the calling code. If False, Play and wait until finish to return control to calling code.</param>
            public static void Play(Uri FileName, bool Async = false)
            {
                WindowPlay w = new WindowPlay();
                var mp = w.MediaElement1;
                if (mp == null)
                {
                    // pode estar sendo fechada a janela
                    return;
                }
                mp.Source = (FileName);
                if (Async)
                    w.Show();
                else
                    w.ShowDialog();
            }
            private void MediaElement1_MediaEnded(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        }
    }
