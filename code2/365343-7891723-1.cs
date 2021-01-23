    class EventHolder
    {
      private event EventHandler<NewUpdateEventArgs> NewUpdate;
    
      public void SubscribeForNewUpdates(object subscriptionOwner, 
                                         Action<NewUpdateEventArgs> callback) 
      {
         if (subscriptionOwner.GetType() == ... or subscriptionOwner is ...)
         {
            this.NewUpdate += .. subscribe callback
         }
      }
     }
      
