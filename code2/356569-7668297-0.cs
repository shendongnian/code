    // XAML in Window A
    <StackPanel>
        <Button Click="Button_Click">Show Window</Button>
        <Button Click="Button_Click_1">Garbage Collect</Button>
    </StackPanel>
    // Code in Window A
     private void Button_Click(object sender, RoutedEventArgs e)
            {
                WindowB windowB = new WindowB(this);
                windowB.Show();
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                GC.Collect();
            }
        // Code in WindowB
        public WindowB(WindowA windowA)
        {
            this.Owner = windowA;
            InitializeComponent();
        }
        ~WindowB()
        {
            Console.WriteLine("Gone up in a puff of smoke");
        }
