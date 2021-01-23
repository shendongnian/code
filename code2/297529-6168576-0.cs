      foreach( var currectFile in files ) {
        Task.Factory.StartNew( cf => {
          using( Bitmap bitmap = new Bitmap( currentFile ) ) {
            bitmap.RotateFlip( RotateFlipType.Rotate180FlipNone );
            bitmap.Save( Path.Combine( newDir, filename ) );
            return string.Format( "Processing {0} on thread {1}", filename, Thread.CurrentThread.ManagedThreadId );
          }
        }, currectFile, cancelToken.Token )
        .ContinueWith( t => this.Text = t.Result, 
                       cancelToken.Token, 
                       TaskContinuationOptions.None, 
                       uiScheduler );
      }
