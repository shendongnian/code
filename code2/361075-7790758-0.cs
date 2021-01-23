    public class Framework 
    { 
        private MainForm mainForm = null; 
        ... // other fields 
 
        public virtual void run() 
        { 
            if (appInitializer!=null) 
            { 
                ISecurityManager securityManager = appInitializer.SecurityManager; 
                if (securityManager!=null) 
                { 
                    if (securityManager.DoLogin()) 
                    { 
                        RegisterDefaultActionsGroup(); 
                        InitializePlugins(appInitializer.Plugins); 
                        // Apply rights for user 
                        ActionsManager.Inst.ApplySecurity(securityManager, securityManager.CurrentUser); 
                        mainForm = new MainForm(); 
                        mainForm.Text = appInitializer.ApplicationTitle; 
                        if (appInitializer.ApplicationIcon != null) 
                        { 
                            mainForm.Icon = appInitializer.ApplicationIcon; 
                        } 
                        CorrectFormSizes(mainForm); 
                        Context[Constants.MainForm] = mainForm;                      
                        MenuManager.Inst.FillMenu(DefaultGroups.MAIN_MENU, mainForm.MainMenu, ActionClick); 
                        if(appInitializer.IsHaveToCreatePanelInfo) PanelInfoManager.Inst.FillInfo(mainForm); 
                        if (appInitializer.IsHaveToCreateToolBar) 
                        { 
                            MenuManager.Inst.FillToolbar(DefaultGroups.MAIN_TOOLBAR, mainForm.MainToolStrip, ActionClick);                             
                        } 
                        mainForm.MainToolStrip.Visible = mainForm.MainToolStrip.Items.Count > 0; 
                        NotifyPluginsAboutShowing(appInitializer.Plugins); 
                        mainForm.Show(); 
                    }                    
                } 
            } 
        } 
 
        ...//other methods 
    }    
 
    static class Program 
    { 
        /// <summary> 
        /// The main entry point for the application. 
        /// </summary> 
        [STAThread] 
        static void Main() 
        { 
            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false); 
 
            Application.Run(new MyHiddenContext());     
            }            
        } 
    public class MyHiddenContext 
        :  ApplicationContext 
    {
        private static Form activeFormInstance;
        public MyHiddenContext()
        {
            this.RunFramework();
        }
        public void RunFramework()
        {
            Framework framework = new Framework(new EArchiveInitializer()); 
            this.framework.run();
            activeFormInstance = Framework.Instance.MainForm;
        }
        public static void ChangeUser()
        {
            activeFormInstance.Close();
            activeFormInstance.Dispose();
            Framework.Instance.MainForm.MainMenuStrip.Items.Clear();              
            Framework.Instance.run();           
        }
    }
