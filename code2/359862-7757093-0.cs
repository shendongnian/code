    [TestMethod]
    public void Callback_is_called()
    {
        // Arrange
		var lw = new AsyncLineWriter();
		object state = new object();
		object callbackState = null;
		var mre = new ManualResetEvent( false );
		AsyncCallback callback = r =>
			{
				callbackState = r.AsyncState;
				lw.EndWriteLine( r );
				mre.Set();
			};
        // Act
		var ar = lw.BeginWriteLine( "test", callback, state );
		mre.WaitOne();
        // Assert
		Assert.AreSame( state, callbackState );
    }
