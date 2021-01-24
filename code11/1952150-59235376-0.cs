    public partial class MainWindow : Window
    { 
        /// <summary>
        /// The bidders name.
        /// </summary>
        private string bidderName;
  
        /// <summary>
        /// The bidders amount.
        /// </summary>
        private int bidderAmount;
        private void butn1_Click(object sender, RoutedEventArgs e)
        {
            [...]
            
            this.bidderAmount = bod;
            [...]
        }
    }
