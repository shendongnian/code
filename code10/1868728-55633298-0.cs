     …..
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.CommandWpf;
    namespace wpf_99
    {
    public class MainWindowViewModel : BaseViewModel
    {
        private int counter =10;
        public int Counter
        {
            get { return counter; }
            set { counter = value; RaisePropertyChanged(); }
        }
        private RelayCommand countDownCommand;
        public RelayCommand CountDownCommand
        {
            get
            {
                return countDownCommand
                ?? (countDownCommand = new RelayCommand(
                 async () =>
                 {
                     for (int i = 10; i > 0; i--)
                     {
                         await Task.Delay(1000);
                         Counter = i;
                     }
                 }
                 ));
            }
        }
