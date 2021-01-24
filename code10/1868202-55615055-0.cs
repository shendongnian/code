public class IPAddressEntryViewModel : ViewModel
    {
        private IPAddress ip;
        private bool isValidIp;
        public bool IsValidIp
        {
            get { return isValidIp; }
            set
            {
                if(isValidIp!= value)
                {
                    isValidIp= value;
                    NotifyPropertyChanged("IsValidIp");
                }
            }
        }
        private string ipAddressText;
        public string IPAddressText
        {
            get { return ipAddressText; }
            set
            {
                if(ipAddressText != value)
                {
                    ipAddressText = value;
                    NotifyPropertyChanged("IPAddressText");
                    //Parsing
                    IsValidIp= IPAddress.TryParse(ipAddressText, out ip);
                }
            }
        }
    }
Then simply bind your button's `IsEnabled` to `IsValidIp` and your TextBox's `Text` to `IPAddressText`. You can also set the border style to follow `IsValidIp` with a DataTrigger, saving you a lot of XAML markup.
This also allows you to perform any other processing you may need to do given the TextBox text in the future.
