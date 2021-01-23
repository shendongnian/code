    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            BootStrap();
            base.OnStartup(e);
        }
        private void BootStrap()
        {
            SetupInternalProxy();
            SetupBrowser();
        }
        private static void SetupBrowser()
        {
            // We may be a new window in the same process.
            if (!WebCore.IsRunning)
            {
                // Setup WebCore with plugins enabled.
                WebCoreConfig config = new WebCoreConfig
                {
                    ProxyServer = "http://127.0.0.1:" + FiddlerApplication.oProxy.ListenPort.ToString(),
                    EnablePlugins = true,
                    SaveCacheAndCookies = true
                };
                WebCore.Initialize(config);
            }
            else
            {
                throw new InvalidOperationException("WebCore should be already running");
            }
        }
        private void SetupInternalProxy()
        {
            FiddlerApplication.AfterSessionComplete += FiddlerApplication_AfterSessionComplete;
            FiddlerApplication.Log.OnLogString += (o, s) => Debug.WriteLine(s);
            FiddlerCoreStartupFlags oFCSF = FiddlerCoreStartupFlags.Default;
            //this line is important as it will avoid changing the proxy for the whole system.
            oFCSF = (oFCSF & ~FiddlerCoreStartupFlags.RegisterAsSystemProxy);
            FiddlerApplication.Startup(
                0,
                oFCSF
                );
        }
        private void FiddlerApplication_AfterSessionComplete(Session oSession)
        {
            Debug.WriteLine(oSession.GetResponseBodyAsString());
        }
    }
