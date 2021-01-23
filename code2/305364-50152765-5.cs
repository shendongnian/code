    using System;
    
    using System.Windows;
    
    using System.Windows.Media.Animation;
    
    
            /// <summary>
        /// Interaction logic for CircularProgressBarBlue.xaml
        /// </summary>
        public partial class CircularProgressBarBlue
        {
            private Storyboard _sb;
    
            public CircularProgressBarBlue()
            {
                InitializeComponent();
                StartStoryBoard();
                IsVisibleChanged += CircularProgressBarBlueIsVisibleChanged;
            }
    
            void CircularProgressBarBlueIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (_sb == null) return;
                if (e != null && e.NewValue != null && (((bool)e.NewValue)))
                {
                    _sb.Begin();
                    _sb.Resume();
                }
                else
                {
                    _sb.Stop();
                }
            }
    
            void StartStoryBoard()
            {
                try
                {
                    _sb = (Storyboard)TryFindResource("spinning");
                    if (_sb != null)
                        _sb.Begin();
                }
                catch
                { }
            }
        }
