    #region Splash Screen
    public  void  ShowSplash(){
    // get the Height & Width of device Screen
    float mainSrcWidth = this.View.Bounds.Width;
    float mainSrcHeight = this.View.Bounds.Height;
    splashScreen = new UIImageView (UIImage.FromFile ("Images/Default.png"));
    splashScreen.Frame = new RectangleF (0, 0, mainSrcWidth, mainSrcHeight);
    //Start the thread;
    ThreadPool.QueueUserWorkItem (delegate {
    Load ();
    }
    }
    this.View.AddSubview(splashScreen);
    }
    #endregion
    #region Load() splashscreen
    private void Load ()
    //Sleep for 3 seconds to simulate a long load.
    Thread.Sleep (new TimeSpan (0, 0, 0, 3));
    this.BeginInvokeOnMainThread (delegate {
    splashScreen.RemoveFromSuperview ();
    splashScreen = null;
    });
    }
    #endregion
