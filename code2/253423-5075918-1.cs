    private void KillTimer_Elapsed( object state )
    {
       // Toggle kill state to indicate activity
    
       killState = ( killState == 1 ) ? 0 : 1;
       this.SetText( killState.ToString( ) );
    
       // Stop the screen saver if it's active and running, 
    
       // otherwise reset the screen saver timer.
    
       // Apparently it's possible for GetScreenSaverRunning()
    
       // to return TRUE before the screen saver has time to 
    
       // actually become the foreground application. So...
    
       // Make sure we're not the foreground window to avoid 
    
       // killing ourself.
    
    
       if( ScreenSaver.GetScreenSaverActive( ) )
       {
          if( ScreenSaver.GetScreenSaverRunning( ) )
          {
             if( ScreenSaver.GetForegroundWindow() != hThisWnd)
                ScreenSaver.KillScreenSaver( );
          }
          else
          {
             // Reset the screen saver timer, so the screen 
    
             // saver doesn't turn on until after a full
    
             // timeout period. If killPeriod is less than 
    
             // ssTimeout the screen saver should never 
    
             // activate.
    
             ScreenSaver.SetScreenSaverActive( TRUE );
          }
       }
    }
