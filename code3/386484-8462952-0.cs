          // Code to execute on Unhandled Exceptions
    private void Application_UnhandledException(object sender,ApplicationUnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is QuitException)
            return;
     
        if (System.Diagnostics.Debugger.IsAttached)
        {
            // An unhandled exception has occurred; break into the debugger
            System.Diagnostics.Debugger.Break();
        }
     
        //MessageBox.Show(e.ExceptionObject.ToString(), "Unexpected error", MessageBoxButton.OK);
     
        var errorWin = new ErrorWindow(e.ExceptionObject, "An unexpected error has occurred. Please click Send to report the error details.")
                           {Title = "Unexpected Error"};
        errorWin.Show();
        //((PhoneApplicationFrame) RootVisual).Source = new Uri("/Views/ErrorWindow.xaml", UriKind.Relative);
         
        e.Handled = true;
    }
     
    private class QuitException : Exception { }
     
    public static void Quit()
    {
        throw new QuitException();
    }
