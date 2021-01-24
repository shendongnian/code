    public class ReceiptPageViewModel : BaseViewModel
    {
        double shift = 0;
        public double Shift
        {
            get { return shift; }
            set { SetProperty(ref shift, value); }
        }
    }
