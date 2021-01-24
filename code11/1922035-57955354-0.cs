    public async Task<bool> onefunction(ChromiumWebBrowser browser) {
      bool success = false;
      try
      {
          succes = (await browser.GetMainFrame().EvaluateScriptAsync("someinfo")).Success;
      }
      catch( Exception ex )
      {
          // TODO: Write Errorlog
      }
    
      return success;
    }
