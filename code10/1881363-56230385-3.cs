       public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void QntLabelLess(object sender, EventArgs e)
        {
            int Qnt=2;
            if (Qnt == 2)
            {
              //  QntLess.TextColor = Color.FromHex("#FF0000");
            //    QntLess.BackgroundColor = Color.FromHex("#3F3C42");
                QntLess.IsEnabled = false;
              
               
            }
            if (Qnt == 10)
            {
                QntPlus.IsEnabled = true;
                QntPlus.TextColor = Color.FromHex("#FF0000");
                QntPlus.BackgroundColor = Color.FromHex("#FF8A00");
            }
            Qnt--;
            QntLabel.Text = Qnt.ToString();
        }
        private void QntLabelPlus(object sender, EventArgs e)
        {
        }
    }
    
