    public partial class MainPage : ContentPage
    {
        private int count = 0;
        private int squared = 0;
        private double sqroot = 0;
        private int milliseconds = 500;
        private bool direction = true;
    
        public MainPage()
        {
            InitializeComponent();
    
            Auto_increment();
        }
    
        private void IncrementCounterClicked(object sender, EventArgs e)
        {
            direction = true;
    
        }
    
        private void Button_Clicked(object sender, EventArgs e)
        {
            direction = false;
    
        }
    
        private void Auto_increment()
        {
            while (true) {
    
                if (direction == true)
                    count++;
                else
                    count--;
    
                squared = count * count;
                sqroot = Math.Sqrt(count);
                CounterLabel.Text = count.ToString();
                Squared.Text = squared.ToString();
                Sqroot.Text = sqroot.ToString();
                Task.Delay(1000);
            }
        }
    }
