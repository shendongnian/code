	public class WithdrawDialog
	{
		private BankAccountCollection _accounts;
		public WithdrawDialog()
		{
			InitializeComponent();
		}
	
		public BankAccountCollection Accounts
		{
			get { return _accounts; }
			set { _accounts = value; PopulateComboBox(_accounts); }
		}
		// populate comboBox with accounts
		private void PopulateComboBox(BankAccountCollection accounts)
		{
			foreach (BankAccount b in accounts)
			{
				comboBoxAccount.Items.Add(b);
			}
		}
	}
