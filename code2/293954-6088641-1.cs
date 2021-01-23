    <Button Command="{Binding Path=MyCommand}" />
    <TextBox <TextBox Text="{Binding Path=Text,
                             UpdateSourceTrigger=PropertyChanged}" />
    public class MainWindowViewModel
    {
        public RelayCommand MyCommand { get; private set; }
        public string Text { get; set; }
        public MainWindowViewModel()
        {
            Text = "";
            MyCommand = new RelayCommand(MyAction, CanExecute);
        }
        private bool CanExecute(object x)
        {
            return Text.Length == 10;
        }
        ....
    }
