       [STAThread]
        static void Main(string[] args) {
    
            #region Application Logic
            //Uninstall
            foreach (string arg in args) {
                if (arg.Split('=')[0] == "/u") {
                    ApplicationLogger.Info("Uninstallation command received.");
                    Process.Start(new ProcessStartInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\msiexec.exe", "/x " + arg.Split('=')[1]));
                    return;
                }
            }
    
            SetupXPO();
            SetupLogging();
    
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
    
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            Application.ThreadException += Application_ThreadException;
    
            try {
                ApplicationLogger.Info("Setting Telerik Theme: " + ConfigurationManager.AppSettings["ThemeToUse"]);
                ThemeResolutionService.ApplicationThemeName = ConfigurationManager.AppSettings["ThemeToUse"];
    
            }
            catch (Exception ex) {
                ApplicationLogger.Error("Exception while setting Telerik Theme.", ex);
                ThemeResolutionService.ApplicationThemeName = "ControlDefault";
    
            }
    
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
    
            if (args.Contains("/dx")) {
                SingleInstanceApplication.Run(new AppMDIRibbonDX());
                ApplicationLogger.Info("Application (DX) started.");
    
            }
            else {
                SingleInstanceApplication.Run(new AppMDIRibbon());
                ApplicationLogger.Info("Application started.");
    
            }
            #endregion
        }
