            List<Action<string>> targets = _action.GetInvocationList().Cast<Action<string>>().ToList();
           
            foreach(var target in targets)
            {
               try
               {
                   target(message);
               }
               catch(CommunicationException)
               {
                   _action -= target;
               }
            }
