    // UserControl AgreementDetails
    public int AgreementID
    {
        get { return Convert.ToInt32(GetValue(AgreementIDProperty)); }
        set { SetValue(AgreementIDProperty, value); }
    }
    //The new property to bind to instead of DataContext
    public UC1001_ActiveAgreementContract Agreement
    {
        get { return (UC1001_ActiveAgreementContract)GetValue(AgreementProperty); }
        private set { SetValue(AgreementProperty, value); }
    }
    public static readonly DependencyProperty AgreementIDProperty = DependencyProperty.Register("AgreementID", typeof(int), typeof(UC1001_AgreementDetails_View), new PropertyMetadata(null));
    //should really be readonly dependency property
    public static readonly DependencyProperty AgreementProperty = DependencyProperty.Register("Agreement", typeof(UC1001_ActiveAgreementContract), typeof(UC1001_AgreementDetails_View), new PropertyMetadata(null));**
    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        int id = AgreementID;
        if (id > 0)
        {
            GetData();
            SetBindingContext();
            this.Visibility = System.Windows.Visibility.Visible;
        }
        else
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
    private void GetData()
    {
        ConsultantServiceClient client = new ConsultantServiceClient();
        _contract = new UC1001_ActiveAgreementContract();
        _contract = client.GetAgreementDetailsByAgreementID(AgreementID);
    }
    private void SetBindingContext()
    {
        this.Agreement = _contract;
    }
