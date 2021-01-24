    namespace DataJuggler.Blazor.Components.Interfaces
    {
    
        #region interface ISpriteSubscriber
        /// <summary>
        /// This interface is used by the AnimationManager to notifiy callers that a refresh occurred.
        /// </summary>
        public interface ISpriteSubscriber
        {
    
            #region Methods
                
                #region Refresh()
                /// <summary>
                /// This method will call StateHasChanged to refresh the UI
                /// </summary>
                void Refresh();
                #endregion
    
                #region Register(Sprite sprite)
                /// <summary>
                /// This method is called by the Sprite to a subscriber so it can register with the subscriber, and 
                /// receiver events after that.
                /// </summary>
                void Register(Sprite sprite);
    
            #endregion
    
            #endregion
    
            #region Properties
    
                #region ProgressBar
                /// <summary>
                /// This is used so the ProgressBar is stored and available to the Subscriber after Registering
                /// </summary>
                ProgressBar ProgressBar { get; set; }
                #endregion
    
            #endregion
    
        }
        #endregion
    
    }
    
