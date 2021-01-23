    ...
    ...
    ...
        /// <summary>
        ///   ask the application to shutdown
        /// </summary>
        public static void RequestShutdown()
        {
           
            // Unless one of the listeners aborted the shutdown, we proceed.  If they abort the shutdown, they are responsible for restarting it too.
    
            var shouldAbortShutdown = false;
            Logger.InfoFormat("Application starting shutdown at {0}...", DateTime.Now);
            var msg = new NotificationMessageAction<bool>(
                Notifications.ConfirmShutdown,
                shouldAbort => shouldAbortShutdown |= shouldAbort);
    
            // recipients should answer either true or false with msg.execute(true) etc.
    
            Messenger.Default.Send(msg, Notifications.ConfirmShutdown);
    
            if (!shouldAbortShutdown)
            {
                // This time it is for real
                Messenger.Default.Send(new NotificationMessage(Notifications.NotifyShutdown),
                                       Notifications.NotifyShutdown);
                Logger.InfoFormat("Application has shutdown at {0}", DateTime.Now);
                Application.Current.Shutdown();
            }
            else
                Logger.InfoFormat("Application shutdown aborted at {0}", DateTime.Now);
        }
        }
