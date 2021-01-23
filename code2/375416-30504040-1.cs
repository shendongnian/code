     public class Admin
        {
            public static AdminPage AdminPage
            {
                get
                {
                    var adminpage = new AdminPage();
                    PageFactory.InitElements(Browser.Driver, adminpage);
                    return adminpage;
                }
    
            }
        }
        public class AdminPage
        {
            string Url = "http://172.18.12.225:4444/admin/admin.aspx";
            string Title = "Login";
            string Text = "Admin";
            public void GoTo()
            {
                Browser.GoTo(Url);
            }
            public bool IsAt()
            {
                return Browser.Title == Title;
            }
            public bool Is_At()
            {
                return Browser.Title == Text;
            }
            [FindsBy(How = How.Id, Using = "ctl16_lblUdpSageMesageCustom")]
            public IWebElement UpdateMessage { get; set; }
    
            [FindsBy(How = How.Id, Using = "hypPreview")]
            public IWebElement BackHomeLink { get; set; }
            //Login
           // [FindsBy(How = How.Id, Using = "ctl14_UserName")]
           // public IWebElement UserNameLink { get; set; }
            [FindsBy(How = How.Id, Using = "ctl14_Password")][CacheLookup]
            public IWebElement PasswordLink { get; set; }
            [FindsBy(How = How.Id, Using = "ctl14_LoginButton")][CacheLookup]
            public IWebElement LoginLink { get; set; }
            //Forgot Password
            [FindsBy(How = How.Id, Using = "ctl14_hypForgotPassword")][CacheLookup]
            public IWebElement FPWLink { get; set; }
            [FindsBy(How = How.Id, Using = "ctl14_wzdForgotPassword_txtUsername")][CacheLookup]
            public IWebElement FPWUserNameLink { get; set; }
            [FindsBy(How = How.Id, Using = "ctl14_wzdForgotPassword_CaptchaValue")][CacheLookup]
            public IWebElement FPWCaptchaLink { get; set; }
            [FindsBy(How = How.Id, Using = "ctl14_wzdForgotPassword_StartNavigationTemplateContainerID_StartNextButton")][CacheLookup]
            public IWebElement FPWNextLink { get; set; }
            [FindsBy(How = How.Id, Using = "ctl14_wzdForgotPassword_StartNavigationTemplateContainerID_CancelButton")][CacheLookup]
            public IWebElement FPWCancelLink { get; set; }
            [FindsBy(How = How.Id, Using = "sfToppane")][CacheLookup]
            public IWebElement TopPane { get; set; }
            [FindsBy(How = How.Id, Using = "sidebar")][CacheLookup]
            public IWebElement sidebar { get; set; }
            //Role
            //[FindsBy(How = How.Id, Using = "ctl19_rptDashBoard_ctl01_hypPageURL")]
            //public IWebElement Role { get; set; }       
            //User
            //[FindsBy(How = How.Id, Using = "ctl19_rptDashBoard_ctl02_hypPageURL")]
            //public IWebElement User { get; set; } 
            public void LogIn(string Username, string Password)
            {
                Browser.MaximizeWindow();
                IWebElement UserNameLink = Browser.WaitForElement(By.Id("ctl14_UserName"), 15);
                UserNameLink.Click();
                UserNameLink.Clear();
                UserNameLink.SendKeys(Username);
                PasswordLink.Click();
                PasswordLink.Clear();
                PasswordLink.SendKeys(Password);
                LoginLink.Click();
            }
    }
