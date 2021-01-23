    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Controls;
    namespace ComboBoxColour
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                this.DataContext = this;
                InitializeComponent();
            }
            // Handling the redrawing of the rectangle according to mouse location
            private void SampleImageCanvas_MouseMove(object sender, MouseEventArgs e)
            {
                //get mouse location relative to the canvas
                Point pt = e.MouseDevice.GetPosition(sender as Canvas);
                
                //here you set the rectangle loction relative to the canvas
                Canvas.SetLeft(ROI, pt.X - (int)(ROI.Width / 2));
                Canvas.SetTop(ROI, pt.Y - (int)(ROI.Height / 2));
            }
            
            private void SampleImageCanvas_MouseDown(object sender, MouseButtonEventArgs e)
            {
                //Here you should handle saving the rectangle location
                //don't forget to calculate the proportion between Canvas's size and real Image's size.
            }
        }
    }
