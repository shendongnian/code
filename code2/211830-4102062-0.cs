            [STAThread]
        public static Int32 Main(string[] args)
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += UnhandledException;
                var app = new App();
                app.DispatcherUnhandledException += DispatcherUnhandledException;
                int run = app.Run();
                
                return run;
            }
            catch (SecurityException)
            {
                // Notify & exit
            }
            catch (Exception e)
            {
                var rwe = e as RuntimeWrappedException;
                if (rwe != null)
                {
                    object wrappedException = rwe.WrappedException;
                    MessageBox.Show(wrappedException.ToString());
                    Environment.Exit(-1);
                }
                throw;
            }
            return -1;
        }
        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ExceptionObject.ToString());
            Environment.Exit(-1);
        }
        private static void DispatcherUnhandledException(object sender,
                                                         DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());
            // Decide if we exit or not
            // ...
            e.Handled = true;
        }
