               try
               {
                 if (client != null && client.State == CommunicationState.Opened)
                     action(subscriber);
                 
               }
               finally
               {
                 Unsubscribe(subscriber);
               }
