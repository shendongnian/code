    /// <summary>
    /// Handles the back-button for a PhoneGap application. When the back-button
    /// is pressed, the browser history is navigated. If no history is present,
    /// the application will exit.
    /// </summary>
    public class BackButtonHandler
    {
      private int _browserHistoryLength = 0;
      private PGView _phoneGapView;
     
      public BackButtonHandler(PhoneApplicationPage page, PGView phoneGapView)
      {
        // subscribe to the hardware back-button
        page.BackKeyPress += Page_BackKeyPress;
     
        // handle navigation events
        phoneGapView.Browser.Navigated += Browser_Navigated;
     
        _phoneGapView = phoneGapView;
      }
     
      private void Browser_Navigated(object sender, NavigationEventArgs e)
      {
        if (e.NavigationMode == NavigationMode.New)
        {
          _browserHistoryLength++;
        }
      }
     
      private void Page_BackKeyPress(object sender, CancelEventArgs e)
      {
        if (_browserHistoryLength > 1)
        {
          _phoneGapView.Browser.InvokeScript("eval", "history.go(-1)");
          _browserHistoryLength -= 2;
          e.Cancel = true;
        }
      }
    }
