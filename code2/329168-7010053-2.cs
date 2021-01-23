    public Form1()
            {
                InitializeComponent(); 
                userControl11.onRadioButtonClick += new           WpfControlLibrary1.UserControl1.ucRadioButtonHandler(userControl11_onRadioButtonClick);
            }
     
     void userControl11_onRadioButtonClick(object sender, WpfControlLibrary1.ucButtonEventArgs e)
            {
                System.Windows.Controls.RadioButton rb = (System.Windows.Controls.RadioButton)sender;
                MessageBox.Show(rb.Content + " Selected!!!!!!!!");
            }      
