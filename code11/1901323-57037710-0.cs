    class MainWindow
    {
    
    	public void callToSecondWindow(){
    		SecondForm sf = new  SecondForm();
    		sf.firstWindowRef = this;
    		sf.showDialog();
    	}
    }
    
    class SecondWindow
    {
    
    	MainWindow mvRef;
    	
    	private void saveNewVaultLine_Click(object sender, RoutedEventArgs e)
        {
            WeekTaskViewModel weekTaskView;
            weekTaskView = new WeekTaskViewModel();
            VaultRecordLine vaultRecordLine = new VaultRecordLine();
            vaultRecordLine.Host = Host.Text;
            vaultRecordLine.Login = Login.Text;
            vaultRecordLine.Password = Password.Text;
            vaultRecordLine.IsPasswordVisible = (bool)PrivatePassword.IsChecked;
            weekTaskView.SaveNewVaultLine(vaultRecordLine);
            mvRef.GetVaultRecordLines();// This Lines call the Main Window function to get records to list
        }
    }
