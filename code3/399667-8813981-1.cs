    class LoginInformation { 
      ...
    }
    
    class HelperForm : Form {
      public LoginInformation { get; set; }
      private void OnCompleted() {
        LoginInformation = ...
        this.Close();
      }
    }
    
    class MainForm : Form { 
      public void ShowHelper() {
        var helper = new HelperForm();
        helper.ShowDialog(this);
        Process(helper.LoginInformation);
      }
    }
    
