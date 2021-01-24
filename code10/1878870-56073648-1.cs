    using GalaSoft.MvvmLight.CommandWpf;
    namespace wpf_99
    {
    public class MainWindowViewModel : BaseViewModel
    {
        private RelayCommand myDcommand;
        public RelayCommand MyDcommand
        {
            get
            {
                return myDcommand
                ?? (myDcommand = new RelayCommand(
                  () =>
                  {
                      Console.WriteLine("It worked OK");
                  }
                 ));
            }
        }
