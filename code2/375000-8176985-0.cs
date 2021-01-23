    using System;
    using System.Threading;
    using System.Windows.Forms; 
    
    public class MainForm : Form
    {
      //Here is an example of one of the _showLoadingForm actions used in one of the programs:
      public static bool _showSplash = true;
      public static void ShowSplashScreen()
      {
        //Ick, DoEvents!  But we were having problems with CloseSplashScreen being called
        //before ShowSplashScreen - this hack was found at
        //http://stackoverflow.com/questions/48916/multi-threaded-splash-screen-in-c/48946#48946
        using(SplashForm splashForm = new SplashForm())
        {
          splashForm.Show();
          while(_showSplash)
            Application.DoEvents();
          splashForm.Close();
        }
      }
    
      //Called in MainForm_Load()
      public static void CloseSplashScreen()
      {
        _showSplash = false;
      }
      
      public MainForm() 
      { 
        Text = "MainForm"; 
        Load += delegate(object sender, EventArgs e) 
        {
          Thread.Sleep(3000);
          CloseSplashScreen(); 
        };
      }
    }
    
    //Multiple programs use this login form, all have the same issue
    public class LoginForm<TMainForm> : Form where TMainForm : Form, new()
    {
      private readonly Action _showLoadingForm;
    
      public LoginForm(Action showLoadingForm)
      {
        Text = "LoginForm";
        Button btnLogin = new Button();
        btnLogin.Text = "Login";
        btnLogin.Click += btnLogin_Click;
        Controls.Add(btnLogin);
        //...
        _showLoadingForm = showLoadingForm;
      }
    
      private void btnLogin_Click(object sender, EventArgs e)
      {
        //...
        this.Hide();
        ShowLoadingForm(); //Problem goes away when commenting-out this line
        new TMainForm().ShowDialog();
        this.Close();
      }
    
      private void ShowLoadingForm()
      {
        Thread loadingFormThread = new Thread(o => _showLoadingForm());
        loadingFormThread.IsBackground = true;
        loadingFormThread.SetApartmentState(ApartmentState.STA);
        loadingFormThread.Start();
      }
    }
    
    public class SplashForm : Form
    {
      public SplashForm() 
      { 
        Text = "SplashForm"; 
      }
    }
    
    public class Program
    {
      public static void Main()
      {
        var loginForm = new LoginForm<MainForm>(MainForm.ShowSplashScreen);
        loginForm.Visible = true;
        Application.Run(loginForm);
      }
    }
