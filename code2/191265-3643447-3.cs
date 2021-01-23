    /// <summary>
    /// Provides static methods for event handling. 
    /// </summary>
    public static class EventManager
    {
    	/// <summary>
    	/// Raises the event specified by <paramref name="handler"/>.
    	/// </summary>
    	/// <typeparam name="TEventArgs">
    	/// The type of the <see cref="EventArgs"/>
    	/// </typeparam>
    	/// <param name="sender">
    	/// The source of the event.
    	/// </param>
    	/// <param name="handler">
    	/// The <see cref="EventHandler{TEventArgs}"/> which 
    	/// should be called.
    	/// </param>
    	/// <param name="e">
    	/// An <see cref="EventArgs"/> that contains the event data.
    	/// </param>
    	public static void OnEvent<TEventArgs>(object sender, EventHandler<TEventArgs> handler, TEventArgs e)
    		 where TEventArgs : EventArgs
    	{
    		// Make a temporary copy of the event to avoid possibility of
    		// a race condition if the last subscriber unsubscribes
    		// immediately after the null check and before the event is raised.
    		EventHandler<TEventArgs> tempHandler = handler;
    
    		// Event will be null if there are no subscribers
    		if (tempHandler != null)
    		{
    			tempHandler(sender, e);
    		}
    	}
    
    	/// <summary>
    	/// Raises the event specified by <paramref name="handler"/>.
    	/// </summary>
    	/// <param name="sender">
    	/// The source of the event.
    	/// </param>
    	/// <param name="handler">
    	/// The <see cref="EventHandler"/> which should be called.
    	/// </param>
    	public static void OnEvent(object sender, EventHandler handler)
    	{
    		OnEvent(sender, handler, EventArgs.Empty);
    	}
    
    	/// <summary>
    	/// Raises the event specified by <paramref name="handler"/>.
    	/// </summary>
    	/// <param name="sender">
    	/// The source of the event.
    	/// </param>
    	/// <param name="handler">
    	/// The <see cref="EventHandler"/> which should be called.
    	/// </param>
    	/// <param name="e">
    	/// An <see cref="EventArgs"/> that contains the event data.
    	/// </param>
    	public static void OnEvent(object sender, EventHandler handler, EventArgs e)
    	{
    		// Make a temporary copy of the event to avoid possibility of
    		// a race condition if the last subscriber unsubscribes
    		// immediately after the null check and before the event is raised.
    		EventHandler tempHandler = handler;
    
    		// Event will be null if there are no subscribers
    		if (tempHandler != null)
    		{
    			tempHandler(sender, e);
    		}
    	}
    }
