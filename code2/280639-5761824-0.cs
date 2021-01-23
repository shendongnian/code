    public partial class MainWindow : Window 
    {
        static Timer _timer;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.image1.Visibility = Visibility.Hidden;
                this.image2.Visibility = Visibility.Visible;
                _timer = new Timer(2000);
                _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
                _timer.Enabled = true; // Enable it
            }
        }
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            textBox1.Dispatcher.Invoke(new Action(delegate()
            {
                _timer.Enabled = false;
                this.image1.Visibility = Visibility.Visible;
                this.image2.Visibility = Visibility.Hidden;
            }));
        }
