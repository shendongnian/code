    public WithdrawDialog()
    {
        InitializeComponent();
    }
    
    public BankAccountCollection Accounts{
        set{
            PopulateComboBox(value);
        }
    }
