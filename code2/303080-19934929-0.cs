    // XAML
    ...       Startup="Application_Startup"
    //code-behind
    private void Application_Startup(object sender, StartupEventArgs e)
    {
     ...
     ...
     // do something.  In fact, here I do a lot of stuff that reflects 
     // some serious recent application illnesss:
    try
            {
                  //http://connect.microsoft.com/VisualStudio/feedback/details/618027/uriformatexception-thrown-by-ms-internal-fontcache-util
                System.Environment.SetEnvironmentVariable("windir", Environment.GetEnvironmentVariable("SystemRoot"));
                // per http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.ietflanguagetag(v=vs.110).aspx
                var cultureName = CultureInfo.CurrentCulture.Name;
                FrameworkElement.LanguageProperty.OverrideMetadata(
                    typeof(FrameworkElement),
                    new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(cultureName)));
                // Setup unhandled exception handlers
                #region Handlers For Unhandled Exceptions
                // anything else to do on startup can go here and will fire after the base startup event of the application
                // First make sure anything after this is handled
                // Creates an instance of the class holding delegate methods that will handle unhandled exceptions.
                CustomExceptionHandler eh = new CustomExceptionHandler();
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(eh.OnAppDomainException);
                // this ensures that any unhandled exceptions bubble up to a messagebox at least
                Dispatcher.CurrentDispatcher.UnhandledException += new DispatcherUnhandledExceptionEventHandler(eh.OnDispatcherUnhandledException);
                #endregion  Handlers For Unhandled Exceptions
                // Start the dispatcher
                // for Galasoft threading and messaging
                DispatcherHelper.Initialize();
            }
            catch (Exception ex)
            {
                ex.PreserveExceptionDetail();
                throw ex;
            }
    }
