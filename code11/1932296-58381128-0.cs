    public class someclass
    {
        public someclass()
        {
            MainWindow main = new MainWindow();
            main.Loaded += Window_Loaded;
        }
    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            main.DrawGrid(Brushes.Black);
        }   
    }
