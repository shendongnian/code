    private void LoadUserControl(){
      
       string controlPath = LastLoadedControl;
    
        if (!string.IsNullOrEmpty(controlPath)) {
            PlaceHolder1.Controls.Clear();
            UserControl uc = (UserControl)LoadControl(controlPath);
            PlaceHolder1.Controls.Add(uc);
        }
    }
    
    protected void Page_Load(object sender, EventArgs e) {  
       LoadUserControl();
    }
