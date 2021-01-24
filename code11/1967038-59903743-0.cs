private Command _onButtonTapCommand;
        public ICommand OnButtonTapCommand { get { return _onButtonTapCommand; } }
        private async void onButtonTapCommand(object obj);
public YourClass()
{
    _onButtonTapCommand = new Command(onButtonTapCommand();
}
