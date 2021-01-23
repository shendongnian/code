    public partial class MyProvidingForm : System.Windows.Forms.Form, IExchangeDataProvider
    {
       // normal form stuff
       // ...
        #region IExchangeDataProvider
        public event EventHandler<FirstDataKindEventArgs> FirstDataKindReceived;
        public event EventHandler<SecondDataKindEventArgs> SecondDataKindReceived;
        public event EventHandler<ThirdDataKindEventArgs> ThirdDataKindReceived;
        public void FireDataReceived(EventArgs Data)
        {
            FirstDataKindEventArgs FirstKindData = Data as FirstDataKindEventArgs;
            if (FirstDataKindEventArgs != null)
                if (FirstDataKindReceived != null)
                    FirstDataKindReceived(FirstKindData);
            //... etc. 
        }
        public void GotSomeDataOfTheFirstKind(int TheID, string SomeName, string Other)
        {
            FirstDataKindEventArgs eArgs = 
                new FirstDataKindEventArgs(TheId, SomeName, Other);
            FireDataReceived(eArgs);
        }
